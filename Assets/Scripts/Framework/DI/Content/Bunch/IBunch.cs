using Asteroids.Framework.DI.Container;

namespace Asteroids.Framework.DI.Content.Bunch {

    /// Objects Bunch (bundle) that used in dependency container
    /// (to store multiple values of the same type)
    /// <br/>
    /// <br/> Used in <see cref="Index.IContentIndex"/> and in <see cref="IDependencyContainer"/>
    /// <remarks>
    /// Изначально, решение было придумано для хранения разных вариантов одного и того-же объекта
    /// (Asteroids: Small, Medium, Large)
    /// <br/>
    /// <br/> 'Add()' method - are internal
    /// <br/>
    /// <br/> Naming variants:
    /// <br/> - IBundle - too generic
    /// <br/> - IBunch - more appropriate (used in Scikit-learn (Python library))
    /// <br/> - IBatch - grouping a set of objects together for processing or management as a single unit
    /// </remarks>
    public interface IBunch { }

}