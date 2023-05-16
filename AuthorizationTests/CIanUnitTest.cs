using OpenQA.Selenium;

namespace AuthorizationTests
{
    public class Tests
    {
        private IWebDriver driver;
        private readonly By _singInButton = By.XPath("//span[text()='Войти']");
        private readonly By _else = By.XPath("//span[text()='Другим способом']");
        private readonly By _countinue = By.XPath("//span[text()='Продолжить']");
        private readonly By _AuthInputButton = By.XPath("//input[@placeholder='Email или id']");
        private readonly By _InputPassword = By.XPath("//input[@placeholder='Пароль']");
        private readonly By _singInButton2 = By.XPath("//button[@data-name='ContinueAuthBtn']");

        private const string _login = "vladimir-andreev-2013@yandex.ru";
        private const string _password = "Test_Cian_2022";


        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Edge.EdgeDriver();
            driver.Navigate().GoToUrl("https://cian.ru");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            var singIn = driver.FindElement(_singInButton);
            singIn.Click();

            var elseIn = driver.FindElement(_else);
            elseIn.Click();

            var login = driver.FindElement(_AuthInputButton);
            login.SendKeys(_login);

            var next = driver.FindElement(_countinue);
            next.Click();

            // Ожидаем появление поля с паролем
            Thread.Sleep(5000);
            var password = driver.FindElement(_InputPassword);
            password.SendKeys(_password);

            var singIn2 = driver.FindElement(_singInButton2);
            singIn2.Click();

        }

        [TearDown]
        public void TearDown() //Метод TearDown вызывается после прохождения тестов. Здесь происходит закрытие веб-приложений
        {
            driver.Quit();
        }
    }
}