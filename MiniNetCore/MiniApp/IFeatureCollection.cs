using System;
using System.Collections.Generic;
using System.Text;

namespace MiniApp
{
    /// <summary>
    /// 我们定义了一个IFeatureCollection接口来表示存放Feature对象的集合
    /// </summary>
    public interface IFeatureCollection : IDictionary<Type, object> { }
    public class FeatureCollection : Dictionary<Type, object>, IFeatureCollection { }
    public static partial class Extensions
    {
        public static T Get<T>(this IFeatureCollection features) => features.TryGetValue(typeof(T), out var value) ? (T)value : default(T);
        public static IFeatureCollection Set<T>(this IFeatureCollection features, T feature)
        {
            features[typeof(T)] = feature;
            return features;
        }
    }
}
