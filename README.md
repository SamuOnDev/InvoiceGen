<!-- Improved compatibility of back to top link: See: https://github.com/othneildrew/Best-README-Template/pull/73 -->
<a name="readme-top"></a>

# InvoiceGen
Invoice generator for sales company


<!-- Database -->
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


<!-- Backend -->
## Backend 
#### Built With:
<img src="https://cdn.discordapp.com/attachments/975450807833079871/1026859452898488420/unknown.png"><img src="https://cdn.discordapp.com/attachments/975450807833079871/1026859481323290664/unknown.png">

- Registrar usuario
- Login usuario
- JWT Bearer para auth
- RBAC User roles


### Used NuGet Packages:
- EntityFrameworkCore.SqlServer
- EntityFrameworkCore.Tools
- VisualStudio.Web.CodeGeneration.Design 
- System.IdentityModel.Tokens.Jwt
- Microsoft.AspNetCore.Authentication.JwtBearer
- Microsoft.IdentityModel.JsonWebTokens


<!-- Frontend -->
## Frontend 
#### Built With:
<img src="https://cdn.discordapp.com/attachments/975450807833079871/1026859522498756708/unknown.png"><img src="https://cdn.discordapp.com/attachments/975450807833079871/1026861343598444635/unknown.png">

- Registro de Usuarios
- Login de Usuarios
- Panel de control Usuario ver y modificar datos propios
- Panel de control Administrador ver y modificar todos los datos


<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONTACT -->
## Contact

Samuel G. - [LinkedIn](https://www.linkedin.com/in/samuel-galindo/)

Project Link: [https://github.com/SamuOnDev/InvoiceGen](https://github.com/SamuOnDev/InvoiceGen)

<p align="right">(<a href="#readme-top">back to top</a>)</p>
