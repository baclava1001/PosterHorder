using PosterHorder.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosterHorder.Helpers
{
    public static class ApiRequestStringBuilder
    {
        public static string BuildApiSearchRequest(string searchStringFromviewModel)
        {
            string modifiedSearchString = searchStringFromviewModel.Replace(" ", "+").ToLower();
            
            return $"{ApiAddress.queryBaseAddress}{modifiedSearchString}&include_adult=false&{ApiAddress.apiKey}";
        }

        public static string BuildApiPosterRequest(string posterPath)
        {
            return $"{ApiAddress.imageBaseAdress}{posterPath}&{ApiAddress.apiKey}";
        }
    }
}
