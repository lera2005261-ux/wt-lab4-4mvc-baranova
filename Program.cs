// Единая культура для всех окружений (локально и на Render): десятичный разделитель — точка
var culture = System.Globalization.CultureInfo.InvariantCulture;
System.Globalization.CultureInfo.DefaultThreadCurrentCulture = culture;
System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = culture;

var builder = WebApplication.CreateBuilder(args);
//коммит
//коммит
//коммит

builder.Services.AddControllersWithViews(options =>
{
    // Русские сообщения для ошибок привязки модели (например, буквы вместо числа)
    var messages = options.ModelBindingMessageProvider;
    messages.SetValueMustBeANumberAccessor(field => $"Поле «{field}» должно быть числом.");
    messages.SetAttemptedValueIsInvalidAccessor((value, field) => $"Значение «{value}» недопустимо для поля «{field}».");
    messages.SetValueMustNotBeNullAccessor(field => $"Заполните поле «{field}».");
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

// 404 и другие коды ошибок показываются через страницу /Home/Status/{код}
app.UseStatusCodePagesWithReExecute("/Home/Status/{0}");

app.UseStaticFiles();
app.UseRouting();

// Маршрут по умолчанию: /Контроллер/Действие/Id
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Render передаёт порт через переменную окружения PORT (по умолчанию 10000)
var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";
app.Run($"http://0.0.0.0:{port}");
