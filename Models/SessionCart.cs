using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OnlineBooks.Infastructure;

namespace OnlineBooks.Models
{
    public class SessionCart : Cart
    {
        //construct
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = 
                services.GetRequiredService<IHttpContextAccessor>()?
                   .HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>
                ("Cart") ?? new SessionCart();
            cart.Session = session;
            return cart;
        }

        //Properties
        [JsonIgnore]
        public ISession Session { get; set; }

        //might have to change override to vertual
        public override void AddItem(Book book, int quantity)
        {
            base.AddItem(book, quantity);
            Session.SetJson("Cart", this);
        }

        public override void RemoveLine(Book book)
        {
            base.RemoveLine(book);
            Session.SetJson("Cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }

    }
}
