
错误	 项目“...csproj”指向“netstandard2.1”。它不能被指向“.NETFramework,Version=v4.8”的项目引用。

错误	 项目“...csproj”指向“netcoreapp3.1”。它不能被指向“.NETFramework,Version=v4.8”的项目引用。	


.NET Core 的项目在引用 .Net Framework的类库时, 如果有App.config配置文件, 则无法读取配置文件, 这时只能引用目标框架为 netCore 或者 .NET Standard 的类库,否则无法正确读取配置文件项目




