# Agreements# Agreements--- Crear base de datos en servidor local como GeneralDB

--Ejecutar el script script.sql

--llenar la tabla con algunos datos

--Para ejecutar el api, correr los siguientes comandos
dotnet restore
dotnet run -p WebApiAgreement/



--El api WebApiAgreement
Esta construido con arquitectura basada en capas
	* Aplicación :Logia de negocio, instanciación de contextos y contratos
	* Infrastructure : Encargado de mapeo entre entidades y objeto de transferencia y manejador de Contextos
	* Dominio: Mapeo de Entidades de base de Datos
	* WebApiAgreement : Usa el patrón mediador para llamar a la capa aplicación desde el controlador que expone los rest

--Razor Agreement, blazor

Contruido en 3 capas
		*Controllers : 	Lógica de consumo de servicio (WebApiAgreement)
		*Modelos : Mapeo de objetos de transferencia DTO
		*Pages : Vista de la aplicación


--Xamarin
		* Main page consume el servicio(webApiAgreement) en el evento OnAppearing() y añade la data al collectionView y es renderizado por el MainPage.xaml




**Se adjunta imagenes del vistas /img
