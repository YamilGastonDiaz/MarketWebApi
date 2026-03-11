using Microsoft.EntityFrameworkCore;
using System.Data;

namespace MarketWebApi.Utilities
{
    public static class HttpContextExtensions
    {
        public async static Task InsertParametrosPaginacion<T>(this  HttpContext httpContext, IQueryable<T> queryable)
        {
            if(httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            double cantidad = await queryable.CountAsync();
            httpContext.Response.Headers.Append("cantidad-total-registros", cantidad.ToString());
        }
    }
}
