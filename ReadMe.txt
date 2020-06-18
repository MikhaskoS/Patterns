Фичи, на которые стоит обратить внимание

1.SOLID
---------------
	OpenClose -демонстрация паттерна "Спецификация" на примере фильтрации. Продвинутый пример
	           комбинации фильтров.
2.Builder
---------------
    InheritanceBuilder - Рекурсивные дженерики.

3.Factories
---------------

4.Prototype
---------------

5.Singleton
---------------
	MoreLinq - расширение библиотеки LINQ, загруженное из NuGet: https://habr.com/ru/post/167831/
	Lazy<T> - ленивая инициализация https://docs.microsoft.com/ru-ru/dotnet/api/system.lazy-1?f1url=https%3A%2F%2Fmsdn.microsoft.com%2Fquery%2Fdev16.query%3FappId%3DDev16IDEF1%26l%3DRU-RU%26k%3Dk(System.Lazy%601);k(TargetFrameworkMoniker-.NETFramework,Version%3Dv4.7.2);k(DevLang-csharp)%26rd%3Dtrue&view=netcore-3.1

6.Adapter
---------------

7.Bridge
    Autofac (NuGet - https://autofac.org/) - позволяет создавать контейнер, в котором регистрируюются
	      объекты. Затем эти объекты можно извлекать.

19. Nullable
---------------
   DynamicObject https://docs.microsoft.com/ru-ru/dotnet/api/system.dynamic.dynamicobject?f1url=https%3A%2F%2Fmsdn.microsoft.com%2Fquery%2Fdev16.query%3FappId%3DDev16IDEF1%26l%3DRU-RU%26k%3Dk(System.Dynamic.DynamicObject);k(TargetFrameworkMoniker-.NETFramework,Version%3Dv4.7.2);k(DevLang-csharp)%26rd%3Dtrue&view=netcore-3.1
   ImpromptuInterface - Библиотека из NuGet (https://github.com/ekonbenefits/impromptu-interface)
                      позволяет обернуть любой объект (статический или динамический) статическим 
					  интерфейсом, даже если он не наследуется от него. 
					  Это делается путем передачи кэшированного кода динамического связывания 
					  внутри прокси.
   Activator - динамически создает экземпляр указанного типа с конструктором по-умолчанию
               https://docs.microsoft.com/ru-ru/dotnet/api/system.activator?f1url=https%3A%2F%2Fmsdn.microsoft.com%2Fquery%2Fdev16.query%3FappId%3DDev16IDEF1%26l%3DRU-RU%26k%3Dk(System.Activator);k(TargetFrameworkMoniker-.NETFramework,Version%3Dv4.7.2);k(DevLang-csharp)%26rd%3Dtrue&view=netcore-3.1