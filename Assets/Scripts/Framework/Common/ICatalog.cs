using Asteroids.Framework.DI.Content.Index;

namespace Asteroids.Framework.Common {

    /// Objects catalog as context
    /// <br/>
    /// <br/> Objects collection - specified as config (ScriptableObject)
    /// <br/>
    /// <remarks>Alternative naming:
    /// <br/> - <b>ICatalog</b>
    /// <br/> - <b>IContent</b>
    /// <br/> - <b>IBundle</b>
    /// </remarks>
    public interface ICatalog { }

    /// <inheritdoc cref="ICatalog"/>
    public interface ICatalog<out TIndex> : ICatalog where TIndex : IContentIndex {

        TIndex GetContents();

    }
}