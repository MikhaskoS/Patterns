�������� � ����, �� ������� ����� �������� ��������

1.SOLID
---------------
	OpenClose -������������ �������� "������������" �� ������� ����������. ����������� ������
	           ���������� ��������.
2.Builder
---------------
    InheritanceBuilder - ����������� ���������.

3.Factories
---------------

4.Prototype
---------------

5.Singleton
---------------
	MoreLinq - ���������� ���������� LINQ, ����������� �� NuGet: https://habr.com/ru/post/167831/
	Lazy<T> - ������� ������������� https://docs.microsoft.com/ru-ru/dotnet/api/system.lazy-1?f1url=https%3A%2F%2Fmsdn.microsoft.com%2Fquery%2Fdev16.query%3FappId%3DDev16IDEF1%26l%3DRU-RU%26k%3Dk(System.Lazy%601);k(TargetFrameworkMoniker-.NETFramework,Version%3Dv4.7.2);k(DevLang-csharp)%26rd%3Dtrue&view=netcore-3.1

6.Adapter. ������ ���� ����� ����� ����� �������������� ������������.
---------------

7.Bridge
---------------
    Autofac (NuGet - https://autofac.org/) - ��������� ��������� ���������, � ������� ���������������
	      �������. ����� ��� ������� ����� ���������.

8. Composite (�����������)
---------------

9. Decorator (���������)
---------------

10. Fa�ade (�����)
---------------

11. Flyweight (��������������)
---------------
    ���� ������ ������������
	������ - �������� ���� � ��������� ������
	������ - �������������� ������ � ��������� ������

12. Proxy (���������)
---------------

13. Chain of Responsibility (������� ������������)
---------------

14. Command (�������)
---------------

15. Interpreter (�������������)
---------------
    ��������������� ���� ��� ��������������� ������� (��������) ��������������� ���������
	       � ����������� ��� � ��� ��������� (�������)
    IReadOnlyList<T>    https://docs.microsoft.com/ru-ru/dotnet/api/system.collections.generic.ireadonlylist-1?f1url=https%3A%2F%2Fmsdn.microsoft.com%2Fquery%2Fdev16.query%3FappId%3DDev16IDEF1%26l%3DRU-RU%26k%3Dk(System.Collections.Generic.IReadOnlyList%601);k(TargetFrameworkMoniker-.NETFramework,Version%3Dv4.7.2);k(DevLang-csharp)%26rd%3Dtrue&view=netcore-3.1

16. Iterator (��������)
---------------

17. Mediator (���������) - ������� ���������
���������� ������, ��������������� ������ �������������� ��������� ��������.
����� �������, �� ��������� ��������� ������ ����� �����, � ���������� ���� � ������� ��� �������������
��������� ���� �� �����. ��� ��������� �� ���������� �������� � �������������.
-> ChatRoom - ����� ����������� ������������������� ����� ����������
-> MediatorWithEvents - ��������� Game, ���������� ����� �������
---------------

18. Memento (���������)
---------------
    ��������� ��������� �������. �������� Undo\Redo

19. Nullable
---------------
    DynamicObject https://docs.microsoft.com/ru-ru/dotnet/api/system.dynamic.dynamicobject?f1url=https%3A%2F%2Fmsdn.microsoft.com%2Fquery%2Fdev16.query%3FappId%3DDev16IDEF1%26l%3DRU-RU%26k%3Dk(System.Dynamic.DynamicObject);k(TargetFrameworkMoniker-.NETFramework,Version%3Dv4.7.2);k(DevLang-csharp)%26rd%3Dtrue&view=netcore-3.1
    ImpromptuInterface - ���������� �� NuGet (https://github.com/ekonbenefits/impromptu-interface)
                      ��������� �������� ����� ������ (����������� ��� ������������) ����������� 
					  �����������, ���� ���� �� �� ����������� �� ����. 
					  ��� �������� ����� �������� ������������� ���� ������������� ���������� 
					  ������ ������.
   Activator - ����������� ������� ��������� ���������� ���� � ������������� ��-���������
               https://docs.microsoft.com/ru-ru/dotnet/api/system.activator?f1url=https%3A%2F%2Fmsdn.microsoft.com%2Fquery%2Fdev16.query%3FappId%3DDev16IDEF1%26l%3DRU-RU%26k%3Dk(System.Activator);k(TargetFrameworkMoniker-.NETFramework,Version%3Dv4.7.2);k(DevLang-csharp)%26rd%3Dtrue&view=netcore-3.1

20. Observer (�����������)
---------------
    WeakEventPattern - ������������� ������ ������� (������ ������)
    Interfaces - ����. ���������� IObservable � IObserver. 
                      ������������ NuGet ����� System.Reactive - ��������� Linq �
                      ��������� �������� � �������� ������� ��� �����������
21. State (���������)
---------------
    Stateless - ��������� ��������� ��� ���������� ������ ���������

22. Strategy (���������) - ������� ���������
������������� ������������ ��������� � ������������ ��� �������.
---------------
    ����� Complex ��� ������ � ������������ �������

23. Template Method (��������� �����) ������� ���������
��������� ����� ������������� ������ ���������, �������� �����������
�������������� ��������� ���� ���������, �� ����� ��� ��������� � �����
---------------

24. Visitor (����������)
---------------