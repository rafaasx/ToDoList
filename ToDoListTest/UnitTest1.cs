using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToDoListTest
{
    [TestClass]
    public class TarefaTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var testProducts = GetTestProducts();
            var tarefas
            var controller = new SimpleProductController(testProducts);

            var result = controller.GetAllProducts() as List<Product>;
            Assert.AreEqual(testProducts.Count, result.Count);
        }
    }
    }
}
