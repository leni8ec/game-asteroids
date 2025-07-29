namespace Asteroids.Framework.DI.Content.Bunch {

    /// Bunch insertion
    /// <br/> Used for constructor injection (to insert this bunch)
    /// <remarks> Naming:
    /// <br/> - Insert
    /// <br/> - Inject (it isn't injecting in the classical sense of DI)
    /// </remarks>
    /// <inheritdoc cref="Bunch{TObject,TKey}"/>
    public class Insert<TKey, TObject> : Bunch<TKey, TObject> { }

}