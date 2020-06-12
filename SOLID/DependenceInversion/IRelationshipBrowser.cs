using System.Collections.Generic;

namespace SOLID.DependenceInversion
{
    // Интерфейс (абстакция), с помощью которого устанавливается
    // коммуникация между hi и low модулями

    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }
}
