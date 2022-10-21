﻿namespace com.myapi.Application.DTO;

public class PagedBaseResponseDTO<T>
{
    public int TotalRegisters { get; private set; }
    public List<T> Data { get; private set; }

    public PagedBaseResponseDTO(int totalRegisters, List<T> data)
    {
        TotalRegisters = totalRegisters;
        Data = data;
    }
}