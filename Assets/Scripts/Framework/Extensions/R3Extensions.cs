using System;

using R3;

using TMPro;

namespace Framework.Extensions
{
    public static class R3Extensions
    {
        public static IDisposable SubscribeToTMPText(this Observable<string> source, TMP_Text text)
        {
            return source.Subscribe(text, static (x, t) => t.text = x);
        }

        public static IDisposable SubscribeToTMPText<T>(this Observable<T> source, TMP_Text text)
        {
            return source.Subscribe(text, static (x, t) => t.text = x.ToString());
        }

        public static IDisposable SubscribeToTMPText<T>(this Observable<T> source, TMP_Text text, Func<T, string> selector)
        {
            return source.Subscribe((text, selector), static (x, state) => state.text.text = state.selector(x));
        }
    }
}