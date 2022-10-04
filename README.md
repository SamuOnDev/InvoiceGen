# InvoiceGen
Invoice generator for sales company

## Database
#### Built With:
<img src="https://cdn.discordapp.com/attachments/975450807833079871/1026859188812529737/unknown.png">

Uno de los apartados más importantes de toda aplicación es su estructura de base de datos, que sentará los cimientos de nuestro desarrollo.

En este caso se ha de modelar las siguientes **entidades**:

- *Usuarios*
- *Empresas*
- *Facturas*
- *Líneas de factura*

Para las cuales se deberán tomar las siguientes **consideraciones**:

- Los usuarios podrán tener el rol de *usuario* o de *administrador*. Un *administrador* podrá acceder a todos los apartados de la aplicación y podrá gestionar todos los usuarios, empresas y facturas con sus correspondientes líneas de factura.
- Las *Empresas* son gestionadas por un único *usuario*. Por lo tanto un *usuario* podrá acceder a la gestión de sus propias empresas.
- Cada *Empresa* tendrá una serie de *Facturas.*
- Cada *Factura* tendrá una serie de *Líneas de factura.*

#### Relationship Scheme:
<p align="center">
  <img src="https://cdn.discordapp.com/attachments/975450807833079871/1026827317479227402/Captura.PNG" style="width: 700px">
</p>


## Backend 
#### Built With:
<img src="https://cdn.discordapp.com/attachments/975450807833079871/1026859452898488420/unknown.png"><img src="https://cdn.discordapp.com/attachments/975450807833079871/1026859481323290664/unknown.png">

### Used NuGet Packages:
- EntityFrameworkCore.SqlServer
- EntityFrameworkCore.Tools
- VisualStudio.Web.CodeGeneration.Design 
- System.IdentityModel.Tokens.Jwt
- Microsoft.AspNetCore.Authentication.JwtBearer
- Microsoft.IdentityModel.JsonWebTokens


## Frontend 
#### Built With:
<img src="https://cdn.discordapp.com/attachments/975450807833079871/1026859522498756708/unknown.png">
<img src="https://cdn.discordapp.com/attachments/975450807833079871/1026861343598444635/unknown.png">

