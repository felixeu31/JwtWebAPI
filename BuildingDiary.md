# Building diary
- Investigación. Autenticación
    - ⭐ [https://jasonwatmore.com/post/2019/10/11/aspnet-core-3-jwt-authentication-tutorial-with-example-api](https://jasonwatmore.com/post/2019/10/11/aspnet-core-3-jwt-authentication-tutorial-with-example-api)
    - ⭐ [https://stackoverflow.com/questions/31309759/what-is-secret-key-for-jwt-based-authentication-and-how-to-generate-it](https://stackoverflow.com/questions/31309759/what-is-secret-key-for-jwt-based-authentication-and-how-to-generate-it)
    - [https://bitoftech.net/2015/02/16/implement-oauth-json-web-tokens-authentication-in-asp-net-web-api-and-identity-2/](https://bitoftech.net/2015/02/16/implement-oauth-json-web-tokens-authentication-in-asp-net-web-api-and-identity-2/)

    [https://medium.com/@vaibhavrb999/jwt-authentication-authorization-in-net-core-3-1-e762a7abe00a](https://medium.com/@vaibhavrb999/jwt-authentication-authorization-in-net-core-3-1-e762a7abe00a)

    [https://enmilocalfunciona.io/construyendo-una-web-api-rest-segura-con-json-web-token-en-net-parte-ii/](https://enmilocalfunciona.io/construyendo-una-web-api-rest-segura-con-json-web-token-en-net-parte-ii/)

    - The OAuth 2.0 Authorization Framework: Bearer Token Usage [https://tools.ietf.org/html/rfc6750](https://tools.ietf.org/html/rfc6750)

        > This specification describes how to use bearer tokens in HTTP
        requests to access OAuth 2.0 protected resources. Any party in
        possession of a bearer token (a "bearer") can use it to get access to
        the associated resources (without demonstrating possession of a
        cryptographic key). To prevent misuse, bearer tokens need to be
        protected from disclosure in storage and in transport.

        > Bearer Token: A security token with the property that any party in possession of the token (a "bearer") can use the token in any way that any other party in possession of it can. Using a bearer token does not require a bearer to prove possession of cryptographic key material (proof-of-possession).

    [https://www.developerro.com/2019/03/12/jwt-api-authentication/](https://www.developerro.com/2019/03/12/jwt-api-authentication/)

- Hashed and salted password

    ⭐ [https://stackoverflow.com/questions/52146528/how-to-validate-salted-and-hashed-password-in-c-sharp](https://stackoverflow.com/questions/52146528/how-to-validate-salted-and-hashed-password-in-c-sharp)

- Ejercicio. Web API. JWT
    - Entity framework
        - New "ASP.NET Core Web Application", template "Empty"
        - Nuggets
            - Microsoft.EntityFrameworkCore
            - Microsoft.EntityFrameworkCore.SqlServer
            - Microsoft.EntityFrameworkCore.Tools
            - Microsoft.Extensions.Configuration
        - Add class "ApplicationDbContext"
        - (Configurar servicio en el Startup.ConfigureServices ) ¿no hace falta?
    - Startup
        - UseRouting
        - UseCors
        - UserMiddleware<JwtMiddleware>
        - UserEdnpoints(MapControllers)
    - Helpers

        AppSettings

    - Add controller
    - Add service
    - Add password salt and hash funcionality
    - Subir a Github
        - git init
        - Visual studio: ignore this local items

        
