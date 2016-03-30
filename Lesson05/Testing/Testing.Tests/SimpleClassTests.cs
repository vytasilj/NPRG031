using System;
using NUnit.Framework;

namespace Testing.Tests
{
    [TestFixture] // Označuje třídu s testy
    public class SimpleClassTests
    {
        [Test] // Metoda je test
        [ExpectedException(typeof(ArgumentNullException))] // V testu bude vyhozená tato výjimka
        public void CreateSimpleClass_IdIsNull_ThrowException()
        {
            new SimpleClass(null, "password");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateSimpleClass_IdIsEmpty_ThrowException()
        {
            new SimpleClass(string.Empty, "password");
        }

        [Test]
        [TestCase(null)] // Spuštění testu se zadaným parametrem
        [TestCase("")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateSimpleClass_InvalidPassword_ThrowException(string pass)
        {
            new SimpleClass("id", pass);
        }

        [Test]
        public void CreateSimpleClass_ValidInput_AllIsSet()
        {
            const string id = "id";
            const string pass = "pass";
            SimpleClass simple = new SimpleClass(id, pass);

            // Kontrola, zda je vše nastavené správně.
            // Pokud podmínka není splněná, tak test skončí s chybou.
            Assert.That(simple.Id, Is.EqualTo(id));
            Assert.That(simple.Password, Is.EqualTo(pass));
        }
    }
}