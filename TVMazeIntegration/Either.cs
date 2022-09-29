using System.Collections.Generic;

namespace TVMazeIntegration;

internal class Either<T1, T2> {

    public T1? AsT1 { get; init; }
    public T2? AsT2 { get; init; }
    private readonly bool _isT1 = false;

    public Either(T1 t) {
        AsT1 = t;
        _isT1 = true;
    }

    public Either(T2 t) {
        AsT2 = t;
        _isT1 = false;
    }

    public T Match<T>(Func<T1, T> left, Func<T2, T> right) {
        return _isT1 ? left(AsT1!) : right(AsT2!);
    }

    public void Match(Action<T1> left, Action<T2> right) {
        if (_isT1) left(AsT1!);
        else right(AsT2!);
    }

}
