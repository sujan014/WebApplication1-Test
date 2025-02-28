using Newtonsoft.Json;
using WebApplication1.Model;
using WebApplication1.Service;

namespace WebApplication1.Repository
{
    public class CalculateService : ICalculateInterface
    {        
        public Result CalculateResult(OperationModel operation)
        {                        
            var result = new Result();
            result.ID = operation.ID;
            result.Inputs = new List<string>();
            foreach(var item in operation.Value)
            {
                result.Inputs.Add(item);
            }
            decimal initPlus = 0;
            decimal initMultiply = 0;
            try
            {
                for(int i = 0; i < operation.Value.Count; i++)
                {
                    var item = operation.Value[i];
                    if (decimal.TryParse(item, out decimal number))
                    {
                        switch (result.ID)
                        {
                            case "Plus":
                                if (i == 0) 
                                    initPlus = number;
                                else
                                    initPlus += number;
                                result.calculation = initPlus.ToString();
                                break;
                            case "Minus":
                                if (i == 0)
                                    initPlus = number;
                                else
                                    initPlus -= number;
                                result.calculation = initPlus.ToString();
                                break;
                            case "Multiplication":
                                if (i == 0)
                                    initMultiply = number;
                                else
                                    initMultiply *= number;
                                result.calculation = initMultiply.ToString();
                                break;
                            case "Division":
                                if (i == 0)
                                    initMultiply = number;
                                else
                                    initMultiply /= number;
                                result.calculation = initMultiply.ToString();
                                break;
                            default:
                                result.calculation = "Invalid Operation";
                                break;
                        }
                    }
                    else
                    {
                        result.calculation = "Invalid Value";
                        break;
                    }
                }                
            }
            catch (Exception ex) 
            {
                result.calculation = "Math Exception";
            }
            if (operation.Operation != null)
            {
                result.result = CalculateResult(operation.Operation);
            }
            string serializedResult = JsonConvert.SerializeObject(result, MyJsonSettings.settings);
            Console.WriteLine("----Serialized result----");
            Console.WriteLine(serializedResult);            
            Result deserializedResult = JsonConvert.DeserializeObject<Result>(serializedResult);            
            return deserializedResult;
        }
    }
}
