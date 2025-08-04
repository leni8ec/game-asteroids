using System;
using JetBrains.Annotations;

namespace Asteroids.GUI.Base {

    public interface IPresenterFactory {
        IPresenter Create(IView view);
    }

    [UsedImplicitly]
    public class PresenterFactory : IPresenterFactory {

        public IPresenter Create(IView view) {
            if (view == null)
                throw new ArgumentNullException(nameof(view));

            string viewTypeName = view.GetType().FullName;
            string presenterTypeName = $"{viewTypeName}Presenter";

            Type presenterType = Type.GetType(presenterTypeName);
            if (presenterType == null)
                throw new Exception($"Presenter type {{{presenterTypeName}}} not found for view {{{viewTypeName}}}");

            IPresenter presenter = Activator.CreateInstance(presenterType) as IPresenter;
            if (presenter == null)
                throw new NullReferenceException($"Presenter {{{presenterTypeName}}} is not derived from {nameof(IPresenter)} interface");

            return presenter;
        }
    }
}