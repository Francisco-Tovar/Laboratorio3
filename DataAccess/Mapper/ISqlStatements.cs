
using DataAcess.Dao;
using Entities_POJO;

namespace DataAcess.Mapper
{
    public interface ISqlStatements
    {
        SqlOperation GetCreateStatement(BaseEntity entity);
        SqlOperation GetRetriveStatement(BaseEntity entity);
        SqlOperation GetRetriveAllStatement();
        SqlOperation GetRetriveAllIDStatement(BaseEntity entity);
        SqlOperation GetUpdateStatement(BaseEntity entity);
        SqlOperation GetDeleteStatement(BaseEntity entity);
    }
}

