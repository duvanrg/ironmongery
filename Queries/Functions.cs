using Newtonsoft.Json;

namespace ironmongery.Queries
{
    public class Functions
    {
        public void ListProducts()
        {
            
        }
        public static IList<T> SaveData<T>(IList<T> list, string filename)
        {
            string json = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText("data/" + filename, json);
            return list;
        }

        public static IList<T> LoadData<T>(string filename)
        {
            if (File.Exists("data/" + filename))
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string json = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<IList<T>>(json) ?? new List<T>();
                }
            }
            else
            {
                return new List<T>();
            }
        }
    }
}