namespace Chestnut_Pro.Views
{
    using Chestnut_Pro.Service;
    using Chestnut_Pro.Service.Utils;
    using ICSharpCode.AvalonEdit.Folding;
    using Newtonsoft.Json;
    using System;
    using System.Dynamic;
    using System.IO;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Threading;
    using YamlDotNet.Core;
    using YamlDotNet.Core.Events;
    using YamlDotNet.Serialization;

    /// <summary>
    /// Interaction logic for DocumentView.xaml
    /// </summary>
    public partial class JsonYamlConverterView : UserControl
    {
        FoldingManager foldingManager;

        private readonly JsonSerializerSettings _defaultJsonSerializerSettings = new()
        {
            FloatParseHandling = FloatParseHandling.Decimal
        };

        public JsonYamlConverterView()
        {
            InitializeComponent();
            InitializeAvalonEditor();
        }

        /// <summary>
        /// Initialize Avalon Editor
        /// </summary>
        private void InitializeAvalonEditor()
        {
            SourceInput_Box.ShowLineNumbers = true;
            TargetOutput_Box.ShowLineNumbers = true;
            foldingManager = FoldingManager.Install(TargetOutput_Box.TextArea);
            var foldingStrategy = new XmlFoldingStrategy();
            DispatcherTimer foldingUpdateTimer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(2),
            };
            foldingUpdateTimer.Tick += (o,args) => foldingStrategy.UpdateFoldings(foldingManager, TargetOutput_Box.Document);
            foldingUpdateTimer.Start();
        }

        /// <summary>
        /// XML formatter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JsonYamlConvert(object sender, RoutedEventArgs e)
        {
            Warning_Message.IsActive = false;
            var conversion = Conversion.Text ?? "YAML to JSON";
            var source = SourceInput_Box.Text;
            if (!string.IsNullOrEmpty(source) && (JsonHelper.IsValid(source) || YamlHelper.IsValidYaml(source)))
            {
                switch (conversion)
                {
                    default:
                    case "YAML to JSON":
                        ConvertYamlToJson(source, (Indentation)YAMLIndentation.SelectedIndex, out var json);
                        TargetOutput_Box.Text = json;
                        break;
                    case "JSON to YAML":
                        ConvertJsonToYaml(source, (Indentation)YAMLIndentation.SelectedIndex, out var yaml);
                        TargetOutput_Box.Text = yaml;
                        break;
                }
            }
            else
            {
                Warning_Message.IsActive = true;
                Warning_Message.Message.Content = "Wrong format!";
            }
        }

        /// <summary>
        /// JSON to YAML
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        private bool ConvertJsonToYaml(string input, Indentation indentation, out string output)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                output = string.Empty;
                return false;
            }

            try
            {
                dynamic? jsonObject = JsonConvert.DeserializeObject<ExpandoObject>(input, _defaultJsonSerializerSettings);
                if (jsonObject is not null and not string)
                {
                    int indent = 0;
                    indent = indentation switch
                    {
                        Indentation.TwoSpaces => 2,
                        Indentation.FourSpaces => 4,
                        _ => throw new NotSupportedException(),
                    };
                    var serializer
                        = Serializer.FromValueSerializer(
                            new SerializerBuilder().BuildValueSerializer(),
                            EmitterSettings.Default.WithBestIndent(indent).WithIndentedSequences());

                    string? yaml = serializer.Serialize(jsonObject);
                    output = yaml ?? string.Empty;
                    return true;
                }

                output = string.Empty;
            }
            catch (JsonReaderException ex)
            {
                output = ex.Message;
            }
            catch (Exception ex)
            {
                output = ex.Message;
            }

            return false;
        }

        /// <summary>
        /// YAML to JSON
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        private bool ConvertYamlToJson(string input, Indentation indentation, out string output)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                output = string.Empty;
                return false;
            }

            try
            {
                using var stringReader = new StringReader(input);

                var deserializer = new DeserializerBuilder()
                    .WithNodeTypeResolver(new DecimalYamlTypeResolver())
                    .Build();

                object? yamlObject = deserializer.Deserialize(stringReader);


                var stringBuilder = new StringBuilder();
                using (var stringWriter = new StringWriter(stringBuilder))
                using (var jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    switch (indentation)
                    {
                        case Indentation.TwoSpaces:
                            jsonTextWriter.Formatting = Formatting.Indented;
                            jsonTextWriter.IndentChar = ' ';
                            jsonTextWriter.Indentation = 2;
                            break;

                        case Indentation.FourSpaces:
                            jsonTextWriter.Formatting = Formatting.Indented;
                            jsonTextWriter.IndentChar = ' ';
                            jsonTextWriter.Indentation = 4;
                            break;

                        default:
                            throw new NotSupportedException();
                    }

                    var jsonSerializer = JsonSerializer.CreateDefault(new JsonSerializerSettings()
                    {
                        Converters = { new DecimalJsonConverter() }
                    });
                    jsonSerializer.Serialize(jsonTextWriter, yamlObject);
                }

                output = stringBuilder.ToString();
                return true;
            }
            catch (SemanticErrorException ex)
            {
                output = ex.Message;
            }
            catch (Exception ex)
            {
                output = ex.Message;
            }

            return false;
        }

        /// <summary>
        /// Copy Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyContent(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(TargetOutput_Box.Text);
        }

        /// <summary>
        /// XML clear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SourceClear(object sender, RoutedEventArgs e)
        {
            SourceInput_Box.Text = string.Empty;
            TargetOutput_Box.Text = string.Empty;
        }

        private class DecimalYamlTypeResolver : INodeTypeResolver
        {
            public bool Resolve(NodeEvent? nodeEvent, ref Type currentType)
            {
                if (nodeEvent is Scalar scalar)
                {
                    // avoid unnecessary parsing attempts
                    bool couldBeNumber =
                        (scalar.Style is not ScalarStyle.SingleQuoted and not ScalarStyle.DoubleQuoted) &&
                        scalar.Value.Length != 0 &&
                        (scalar.Value[0] is >= '0' and <= '9' || scalar.Value[0] == '-');

                    if (couldBeNumber && decimal.TryParse(scalar.Value, out _))
                    {
                        currentType = typeof(decimal);
                        return true;
                    }
                }
                return false;
            }
        }

        private class DecimalJsonConverter : JsonConverter<decimal>
        {
            public override decimal ReadJson(JsonReader reader, Type objectType, decimal existingValue, bool hasExistingValue, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }

            public override void WriteJson(JsonWriter writer, decimal value, JsonSerializer serializer)
            {
                // prevent adding trailing zeros
                writer.WriteRawValue(value.ToString());
            }
        }
    }
}
