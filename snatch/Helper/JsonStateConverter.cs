using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace snatch.Helper
{
    public class JsonStateConverter : IStateConverter
    {
        public T From<T>(string fromConvert)
        {
            if (string.IsNullOrWhiteSpace(fromConvert))
                return default(T);
            T result;
            try
            {
                result = JsonConvert.DeserializeObject<T>(fromConvert);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new JsonSerializationException(ex.Message, ex);
            }
            return result;
        }

        public string To<T>(T toConvert)
        {
            if (toConvert==null)
                return default(string);

            string result;
            try
            {
                result = JsonConvert.SerializeObject(toConvert);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new JsonSerializationException(ex.Message, ex);
            }
            return result;
        }
    }
}
