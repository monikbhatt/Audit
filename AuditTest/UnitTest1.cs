
using Audit;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace AuditTest
{
   
    public class UnitTest
    {

        [TestCaseSource(typeof(AuditTestSource), "SaveCases")]
        public void TestSave(IAuditDataAdapter auditDataAdapter, IAuditEventUser auditEventUser, SampleProduct product, string eventType, string comment)
        {
            //Save Old Price before changing it
            var oldProductPrice = product.Price;
            var newProductPrice = 20;
            IAuditEvent ev;

            // create audit trail object with scope to trak changes of product entity
            using (var auditTrail = AuditTrailFactory.Create(eventType, () => product, auditDataAdapter, auditEventUser))
            {
                ev = auditTrail.Event;
                //change product price
                product.Price = newProductPrice;
                //save audit comment 
                auditTrail.Comment(comment);
                auditTrail.Save();
               
            }

            //check if audit event is created with correct event type
            Assert.AreEqual(eventType, ev.EventType);

            //check if audit event has comment 
            Assert.True(ev.Comments.Contains(comment));

            //check if audit event has the  old obj stored with orignial price
            var oldObj = (JToken) ev.TargetEntity.Old;
            Assert.AreEqual(oldObj.ToObject<SampleProduct>().Price,oldProductPrice);

            //check if audit event has the  new obj stored with new price
            var newObj = (JToken)ev.TargetEntity.New;
            Assert.AreEqual(newObj.ToObject<SampleProduct>().Price, newProductPrice);

            //check if audit event has correct user information 
            Assert.AreEqual(ev.User.UserName, auditEventUser.UserName);

        }
    }
}
