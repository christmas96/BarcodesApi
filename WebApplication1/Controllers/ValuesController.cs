using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<Barcode> Get()
        {
            using (BarcodesEntities db = new BarcodesEntities())
            {
                return db.Barcodes.ToList();
            }            
        }

        // GET api/values/5
        public Barcode Get(string id)
        {
            string code = id;
            Barcode barcode = new Barcode();
            using (BarcodesEntities db = new BarcodesEntities())
            {
                barcode = db.Barcodes.Where(x => x.Code.Equals(code)).FirstOrDefault();
            }
            return barcode;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
