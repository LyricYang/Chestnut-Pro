namespace Chestnut_Pro.Service.Utils
{
    using System;
    using YamlDotNet.Serialization;

    public class YamlHelper
    {
        /// <summary>
        /// Detects whether the given string is a valid YAML or not.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsValidYaml(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            input = input!.Trim();

            try
            {
                object? result = new DeserializerBuilder().Build().Deserialize<object>(input);
                return result is not null and not string;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
