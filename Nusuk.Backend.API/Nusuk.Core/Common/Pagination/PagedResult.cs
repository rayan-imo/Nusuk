namespace Nusuk.Core.Common.Pagination;

public record PagedResult<T>(List<T>Items,int PageNumber,int PageSize,int TotalCount);
