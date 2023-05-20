using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using UtilityBot.Configuration;
using UtilityBot.Services;
using UtilityBot.Models;

namespace UtilityBot.Controllers
{
    public class TextMessageController
    {
        private readonly ITelegramBotClient _telegramClient;
        private readonly IStorage _memoryStorage;

        public TextMessageController(IStorage memoryStorage, ITelegramBotClient botClient)
        {
            _telegramClient = botClient;
            _memoryStorage = memoryStorage;
        }

        public async Task Handle(Message message, CancellationToken ct)
        {
            switch (message.Text)
            {
                case "/start":

                    // Объект, представляющий кноки
                    var buttons = new List<InlineKeyboardButton[]>();
                    buttons.Add(new[]
                    {
                        InlineKeyboardButton.WithCallbackData($"Количество символов", $"text"),
                        InlineKeyboardButton.WithCallbackData($"Сумма чисел", $"nums")
                    });

                    // передаем кнопки вместе с сообщением (параметр ReplyMarkup)
                    await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"<b>Наш бот считает сумму чисел или количество символов в сообщении.</b> {Environment.NewLine}" +
                        $"{Environment.NewLine}Для подсчета суммы чисел введите числа через пробел.{Environment.NewLine}", cancellationToken: ct, parseMode: ParseMode.Html, replyMarkup: new InlineKeyboardMarkup(buttons));

                    break;
                default:
                    if (_memoryStorage.GetSession(message.Chat.Id).textType == "nums")
                    {
                        await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"{CountNums.SumNubers(message.Text)}",
                            cancellationToken: ct);
                    }
                    else
                    {
                        await _telegramClient.SendTextMessageAsync(message.Chat.Id,
                            $"Длина сообщения: {CountText.GetCharCount(message.Text)}", cancellationToken: ct);
                    }
                    break;
            }
        }
    }
}