<!-- Improved compatibility of back to top link: See: https://github.com/othneildrew/Best-README-Template/pull/73 -->
<a name="readme-top"></a>

# InvoiceGen
Invoice generator for sales company

The project consists of an **invoice management application** where we have an administration panel for managing invoices, companies, users and viewing and generating PDF invoices.

The content of the application is divided into 2 main sections:

- **Administration panel.**

   It is the *FrontEnd* part of the project that is developed with *Angular* technology. It is the one that allows us to visually manage all the data of our application, in a safe and orderly manner.

- **Restaurant API**

   It is the *BackEnd* part of the application that is responsible for data persistence and its corresponding operations. Developed in *.NET.*

Both sections have been developed in parallel throughout the development sprints, in this way I have verified the operation and integration of both.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- Frontend -->
## Frontend 
#### Built With:
<img src="https://cdn.discordapp.com/attachments/975450807833079871/1026859522498756708/unknown.png"><img src="https://cdn.discordapp.com/attachments/975450807833079871/1026861343598444635/unknown.png">

- User Registration
- User Login
- User control panel view and modify own data
- Admin Control Panel view and modify all user data
- Company panel in user menu
- Creation of invoices with own list of companies by user
- PDF preview and button to export and download in PDF format

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- Backend -->
## Backend 
#### Built With:
<img src="https://cdn.discordapp.com/attachments/975450807833079871/1026859452898488420/unknown.png"><img src="https://cdn.discordapp.com/attachments/975450807833079871/1026859481323290664/unknown.png">

- Register user
- User login
- JWT Bearer for auth
- RBAC User roles
- CRUD Users
- CRUD Company
- CRUD of invoices
- Saving of each product generated in the database

### Used NuGet Packages:
- EntityFrameworkCore.SqlServer
- EntityFrameworkCore.Tools
- VisualStudio.Web.CodeGeneration.Design 
- System.IdentityModel.Tokens.Jwt
- Microsoft.AspNetCore.Authentication.JwtBearer
- Microsoft.IdentityModel.JsonWebTokens

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- Database -->
## Database
#### Built With:
<img src="https://cdn.discordapp.com/attachments/975450807833079871/1026859188812529737/unknown.png">

One of the most important sections of any application is its database structure, in this case the following **entities** have been modeled:

- *Users*
- *Companies*
- *Bills*
- *Invoice lines*

For which the following **considerations** have been taken:

- Users can have the role of *user* or *administrator*. An *administrator* can access all sections of the application and can manage all users, companies and invoices with their corresponding invoice lines.
- The *Companies* are managed by a single *user*. Therefore a *user* can only access the management of their own companies.
- Each *Company* has a series of *Invoices.*
- Each *Invoice* has a series of *Invoice Lines.*

#### Relationship Scheme:
<p align="center">
  <img src="https://cdn.discordapp.com/attachments/975450807833079871/1026827317479227402/Captura.PNG" style="width: 700px">
</p>

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` for more information.

<!-- CONTACT -->
## Contact

Samuel G. - [LinkedIn](https://www.linkedin.com/in/samuel-galindo/)

Project Link: [https://github.com/SamuOnDev/InvoiceGen](https://github.com/SamuOnDev/InvoiceGen)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

---

# InvoiceGen
Generador de facturas para empresa de ventas

El proyecto consiste en una **aplicación de gestión de facturas,** donde tenemos un panel de administración para la gestión de las facturas, empresas, usuarios y visualización y generación de las facturas en PDF.

El contenido de la aplicación está dividido en 2 apartados principales:

- **Panel de administración.**

  Es la parte de *FrontEnd* del proyecto que está desarrollado con la tecnología *Angular.* Es el que permite de manera visual gestionar todos los datos de nuestra aplicación, de manera segura y ordenada.

- **API Rest.**

  Es la parte de *BackEnd* de la aplicación que se encarga de la persistencia de los datos y sus operaciones correspondientes. Desarrollado en *.NET.*

Ambos apartados se han desarrollado de manera paralela a lo largo de los sprints del desarrollo, de esta forma he verificado el funcionamiento y la integración de ambos.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- Frontend -->
## Frontend 
#### Tecnologías usadas:
<img src="https://cdn.discordapp.com/attachments/975450807833079871/1026859522498756708/unknown.png"><img src="https://cdn.discordapp.com/attachments/975450807833079871/1026861343598444635/unknown.png">

- Registro de Usuarios
- Login de Usuarios
- Panel de control Usuario ver y modificar datos propios
- Panel de control Administrador ver y modificar todos los datos de los usuarios
- Panel de empresas en menú de usuario
- Creación de facturas con listado propio de empresas por usuario
- Visualización previa de PDF y botón para exportar y descargar en formato PDF

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- Backend -->
## Backend 
#### Tecnologías usadas:
<img src="https://cdn.discordapp.com/attachments/975450807833079871/1026859452898488420/unknown.png"><img src="https://cdn.discordapp.com/attachments/975450807833079871/1026859481323290664/unknown.png">

- Registrar usuario
- Login usuario
- JWT Bearer para auth
- RBAC User roles
- CRUD Users
- CRUD Company
- CRUD de facturas
- Guardado de cada producto generado en base de datos

### Paquetes NuGet usados:
- EntityFrameworkCore.SqlServer
- EntityFrameworkCore.Tools
- VisualStudio.Web.CodeGeneration.Design 
- System.IdentityModel.Tokens.Jwt
- Microsoft.AspNetCore.Authentication.JwtBearer
- Microsoft.IdentityModel.JsonWebTokens

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- Database -->
## Database
#### Tecnologías usadas:
<img src="https://cdn.discordapp.com/attachments/975450807833079871/1026859188812529737/unknown.png">

Uno de los apartados más importantes de toda aplicación es su estructura de base de datos, en este caso se han modelado las siguientes **entidades**:

- *Usuarios*
- *Empresas*
- *Facturas*
- *Líneas de factura*

Para las cuales se han tomado las siguientes **consideraciones**:

- Los usuarios pueden tener el rol de *usuario* o de *administrador*. Un *administrador* puede acceder a todos los apartados de la aplicación y puede gestionar todos los usuarios, empresas y facturas con sus correspondientes líneas de factura.
- Las *Empresas* son gestionadas por un único *usuario*. Por lo tanto, un *usuario* solo puede acceder a la gestión de sus propias empresas.
- Cada *Empresa* tiene una serie de *Facturas.*
- Cada *Factura* tiene una serie de *Líneas de factura.*

#### Esquema de relaciones:
<p align="center">
  <img src="https://cdn.discordapp.com/attachments/975450807833079871/1026827317479227402/Captura.PNG" style="width: 700px">
</p>

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- LICENSE -->
## License

Distribuido bajo la licencia MIT. Consulte `LICENCIA` para obtener más información.

<!-- CONTACT -->
## Contacto

Samuel G. - [LinkedIn](https://www.linkedin.com/in/samuel-galindo/)

Link del proyecto: [https://github.com/SamuOnDev/InvoiceGen](https://github.com/SamuOnDev/InvoiceGen)

<p align="right">(<a href="#readme-top">back to top</a>)</p>
