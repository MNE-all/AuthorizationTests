using OpenQA.Selenium;

namespace AuthorizationTests
{
    public class Tests
    {
        private IWebDriver driver;
        private readonly By _singInButton = By.XPath("//span[text()='�����']");
        private readonly By _else = By.XPath("//span[text()='������ ��������']");
        private readonly By _countinue = By.XPath("//span[text()='����������']");
        private readonly By _AuthInputButton = By.XPath("//input[@placeholder='Email ��� id']");
        private readonly By _InputPassword = By.XPath("//input[@placeholder='������']");
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

            // ������� ��������� ���� � �������
            Thread.Sleep(5000);
            var password = driver.FindElement(_InputPassword);
            password.SendKeys(_password);

            var singIn2 = driver.FindElement(_singInButton2);
            singIn2.Click();

        }

        [TearDown]
        public void TearDown() //����� TearDown ���������� ����� ����������� ������. ����� ���������� �������� ���-����������
        {
            driver.Quit();
        }
    }
}