//using Microsoft.Extensions.Configuration;
//using OpenAI.Chat;
//using OpenAI_API;
//using OpenAI_API.Chat;
//using System.Threading.Tasks;

//namespace WAAL.Infrastructure.Services
//{
//    public class OpenAIService
//    {
//        private readonly string _apiKey;

//        public OpenAIService(IConfiguration configuration)
//        {
//            _apiKey = configuration["OpenAI:ApiKey"];
//        }

//        public async Task<string> GetChatResponse(string userMessage)
//        {
//            var api = new OpenAIAPI(_apiKey);
//            var chatRequest = new ChatRequest()
//            {
//                Model = "gpt-4",
//                Temperature = 0.7,
//                Messages = new List<ChatMessage>
//                {
//                    new ChatMessage(ChatMessageRole.System, "Bạn là một chuyên gia tư vấn laptop, hãy trả lời ngắn gọn, hấp dẫn."),
//                    new ChatMessage(ChatMessageRole.User, userMessage)
//                }
//            };

//            var response = await api.Chat.CreateChatCompletionAsync(chatRequest);
//            return response?.Choices?[0]?.Message?.Content ?? "Xin lỗi, tôi không thể trả lời ngay bây giờ.";
//        }
//    }
//}
