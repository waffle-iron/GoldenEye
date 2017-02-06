﻿using System;
using System.Globalization;
using GoldenEye.Shared.Core.Extensions.Basic;
using Newtonsoft.Json;

namespace GoldenEye.Shared.Core.Utils.Serialization
{
    public static class JsonSerializer
    {
        //public static bool TryDeserializeObject<T>(string json, out T result, CultureInfo culture )
        //{
        //    var jsonSerializerSettings = new JsonSerializerSettings { Culture = culture  };
        //    Newtonsoft.Json.JsonSerializer jsonSerializer = Newtonsoft.Json.JsonSerializer.Create(jsonSerializerSettings);

        //    if (json == null)
        //    {
        //        result = ObjectExtensions.GetDefault<T>();
        //        return false;
        //    }

        //    result = (T)Newtonsoft.Json.Linq.JToken.Parse("'" + json + "'").ToObject(typeof(T), jsonSerializer);
        //    return true;
        //}

        //public static object DeserializeObject(string json, Type type, CultureInfo culture = null)
        //{
        //    var jsonSerializerSettings = new JsonSerializerSettings { Culture = culture  };
        //    Newtonsoft.Json.JsonSerializer jsonSerializer = Newtonsoft.Json.JsonSerializer.Create(jsonSerializerSettings);

        //    return json != null ?
        //        Newtonsoft.Json.Linq.JToken.Parse("'" + json + "'").ToObject(type, jsonSerializer)
        //        : ObjectExtensions.GetDefault(type);
        //}

        public static string Serialize(object obj, CultureInfo culture = null)
        {
            if (obj == null)
                return null;

            var jsonSerializerSettings = new JsonSerializerSettings { Culture = culture  };
            var result = JsonConvert.SerializeObject(obj, jsonSerializerSettings.Formatting, (JsonConverter)DateTimeJsonConverter.Get());

            if (obj is DateTime)
            {
                result = string.Format("new Date('{0}')", obj);
            }
            return result;
        }

        public static T Deserialize<T>(string json, CultureInfo culture = null)
        {
            var jsonSerializerSettings = new JsonSerializerSettings { Culture = culture  };
            return JsonConvert.DeserializeObject<T>(json, jsonSerializerSettings);
        }
    }
}