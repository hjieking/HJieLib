using SqlSugar;

namespace Hj.SqlSugarFactory
{
    public interface ISqlSugarFactory
    {
        SqlSugarClient CreateClient(string name);
    }
}