namespace Chestnut_Pro.Service
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// Http Search API
    /// </summary>
    public class HttpSearchAPI
    {
        /// <summary>
        /// Github User Info
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<string> GetGithubUserAsync(string user)
        {
            var url = string.Format("https://api.github.com/users/{0}", user);
            var result = await SearchAPIAsync(url);
            return result;

        }

        /// <summary>
        /// Github User Relationship
        /// </summary>
        /// <param name="user"></param>
        /// <param name="relationship"></param>
        /// <returns></returns>
        public static async Task<string> GetGithubUserRelationshipAsync(string user, string relationship)
        {
            var url = string.Format("https://api.github.com/users/{0}/{1}", user, relationship);
            var result = await SearchAPIAsync(url);
            return result;
        }

        /// <summary>
        /// All Repos
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<string> GetGithubReposAsync(string user)
        {
            var url = string.Format("https://api.github.com/users/{0}/repos",user);
            var result = await SearchAPIAsync(url);
            return result;
        }

        /// <summary>
        /// Repo Detail
        /// </summary>
        /// <param name="user"></param>
        /// <param name="repoName"></param>
        /// <returns></returns>
        public static async Task<string> GetGithubRepoAsync(string user, string repoName)
        {
            var url = string.Format("https://api.github.com/repos/{0}/{1}", user, repoName);
            var result = await SearchAPIAsync(url);
            return result;
        }

        /// <summary>
        /// USA Stock
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        public static async Task<string> GetUSAStockAsync(string gid)
        {
            var url = string.Format("http://web.juhe.cn:8080/finance/stock/usa?gid={0}&key=0b3943ea6229568151649a5d1636e30f", gid);
            var result = await SearchAPIAsync(url);
            return result;
        }

        /// <summary>
        /// Gold Price
        /// </summary>
        /// <returns></returns>
        public static async Task<string> GetSHGoldAsync()
        {
            var url = @"http://web.juhe.cn/finance/gold/shgold?key=77cd2d4edefb554c20bbf35b3790be3d";
            var result = await SearchAPIAsync(url);
            return result;
        }

        private static async Task<string> SearchAPIAsync(string url)
        {
            var result = string.Empty;
            using (var client = new HttpClient() { Timeout = TimeSpan.FromSeconds(30) })
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.75 Safari/537.36");
                var response = client.GetAsync(url).GetAwaiter().GetResult();
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result = await response.Content.ReadAsStringAsync();
                }

                return result.Trim();
            }
        }
    }
}
