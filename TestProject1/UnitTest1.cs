using Newtonsoft.Json;
using WebApplication1.Model;
using WebApplication1.Repository;

namespace TestProject1
{    
    public class Tests
    {
        public CalculateService _service = new CalculateService();

        [TestCase("{\r\n  \"Maths\": {\r\n    \"Operation\": {\r\n      \"@ID\": \"Plus\",\r\n      \"Value\": [\r\n        \"2\",\r\n        \"3\"\r\n      ]\r\n    }\r\n  }\r\n}")]
        public void TestFunction(string jsonString)
        {
            var objectModel = JsonConvert.DeserializeObject<MathModel>(jsonString);
            Assert.IsNotNull(objectModel);

            var resultModel = _service.CalculateResult(objectModel.Maths.Operation);
            Assert.IsNotNull(resultModel);
        }
    }
}
