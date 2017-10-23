using Microsoft.VisualStudio.TestTools.UnitTesting;
using WSConvertisseur.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSConvertisseur.Models;
using System.Net;
using System.Web.Http.Results;


namespace WSConvertisseur.Controllers.Tests
{
    [TestClass()]
    public class DeviseControllerTests
    {

        [TestMethod()]
        public void GetTest()
        {
            DeviseController dc = new DeviseController();

            IEnumerable<Devise> devises = dc.Get();
            Assert.AreEqual(devises.Count(), 3);
        }

        [TestMethod()]
        public void GetTest1()
        {
            DeviseController dc = new DeviseController();

            OkNegotiatedContentResult<Devise> result = (OkNegotiatedContentResult<Devise>)dc.Get(2);
            Assert.AreEqual(result.Content.Id, 2);

        }

        [TestMethod()]
        public void PostTest()
        {
            DeviseController dc = new DeviseController();

            Devise toAdd = new Devise(4,"Test", 12000);
            dc.Post(toAdd);

            IEnumerable<Devise> devises2 = dc.Get();

            Assert.AreEqual(devises2.Count(), 4);
        }

        [TestMethod()]
        public void PutTest()
        {
            DeviseController dc = new DeviseController();
            IEnumerable<Devise> devises = dc.Get();

            Devise toEdit = devises.FirstOrDefault();
            Assert.IsNotNull(toEdit);
            
            toEdit.Nom = "Donatien";


            var result = dc.Put(1, toEdit) as StatusCodeResult;
           
            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            DeviseController dc = new DeviseController();
            OkNegotiatedContentResult<Devise> toDelete = (OkNegotiatedContentResult<Devise>)dc.Get(2);

            OkNegotiatedContentResult<Devise> result = (OkNegotiatedContentResult<Devise>)dc.Delete(2);
            Assert.AreEqual(result.Content, toDelete.Content);
        }
    }
}