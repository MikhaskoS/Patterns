Описание и фичи, на которые стоит обратить внимание

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

6.Adapter. Играет роль моста между двумя несовместимыми интерфейсами.
---------------

7.Bridge
---------------
    Autofac (NuGet - https://autofac.org/) - позволяет создавать контейнер, в котором регистрируюются
	      объекты. Затем эти объекты можно извлекать.

8. Composite (Компоновщик)
---------------

9. Decorator (Декоратор)
---------------

10. Faсade (Фасад)
---------------

11. Flyweight (Приспособленец)
---------------
    Есть пример тестирования
	Пример - хранение имен с экономией памяти
	Пример - форматирование текста с экономией памяти

12. Proxy (Посредник)
---------------

13. Chain of Responsibility (Цепочка обязанностей)
---------------

14. Command (Команда)
---------------

15. Interpreter (Интерпретатор)
---------------
    Демонстрируется идея для синтаксического анализа (лексинга) математического выражения
	       и превращения его в ООП структуру (парсинг)
    IReadOnlyList<T>    https://docs.microsoft.com/ru-ru/dotnet/api/system.collections.generic.ireadonlylist-1?f1url=https%3A%2F%2Fmsdn.microsoft.com%2Fquery%2Fdev16.query%3FappId%3DDev16IDEF1%26l%3DRU-RU%26k%3Dk(System.Collections.Generic.IReadOnlyList%601);k(TargetFrameworkMoniker-.NETFramework,Version%3Dv4.7.2);k(DevLang-csharp)%26rd%3Dtrue&view=netcore-3.1

16. Iterator (Итератор)
---------------

17. Mediator (Посредник) - паттерн поведения
Определяет объект, инкапсулирующий способ взаимодействия множества объектов.
Иными словами, он связывает различные классы между собой, в результате чего у классов нет необходимости
ссылаться друг на друга. Это позволяет их независимо изменять и анализировать.
-> ChatRoom - обмен сообщениями междупользователями через посредника
-> MediatorWithEvents - посредник Game, работающий через события
---------------

18. Memento (Хранитель)
---------------
    Храниение состояний объекта. Операции Undo\Redo

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

20. Observer (наблюдатель)
---------------
    WeakEventPattern - Прослушивание слабых событий (сборка мусора)
    Interfaces - спец. интерфейсы IObservable и IObserver. 
                      Используется NuGet пакет System.Reactive - расширяет Linq и
                      позволяет работать с потоками событий как коллекциями
21. State (состояние)
---------------
    Stateless - сторонняя библитека для построения машины состояния

22. Strategy (Стратегия) - паттерн поведения
Инкапсулирует определенное поведение с возможностью его подмены.
---------------
    Класс Complex для работы с комплексными числами

23. Template Method (Шаблонный метод) паттерн поведения
Шаблонный метод предоставляет основу алгоритма, позволяя наследникам
переопределять некоторые шаги алгоритма, не меняя его структуры в целом
---------------

24. Visitor (Посетитель)
---------------