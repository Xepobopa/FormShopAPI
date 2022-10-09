using WebAPI.Models;
using Newtonsoft.Json;

namespace WebAPI.Controllers
{
    public class ControllerJson
    {
        public ControllerJson(string filename = "database.json")
        {
            if (!File.Exists(filename))
                throw new FileNotFoundException("No database configuration file both found");
            m_jsonModel = JsonConvert.DeserializeObject<JsonModel>(File.ReadAllText(filename));
        }

        private JsonModel? m_jsonModel;
        public JsonModel jsonModel
        {
            get
            {
                if (m_jsonModel != null)
                    return m_jsonModel;
                else
                    throw new NullReferenceException("Can't open json file or file is empty");
            }
        }
    }
}
