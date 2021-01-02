using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicShop.Domain.Enums
{
    public enum AlertType
    {
        Success = 1,
        Info = 2,
        Warning = 3,
        Danger = 4,
    }

    public enum DbOperationStatusEnum
    {
        Success,
        Failed,
        Repeated,
        Intersected,
        OldPasswordNotCorrect,
        ItemNotExist,
        ClusterRepeated,
        SuccessWithMessage,
        DetailsRepeated,
        OrderRepeated,
        Updated,
        Inserted,
        RangeRepeated,
        ListEmpty,
    }

    public enum AdminRoles
    {
        Role1,
        Role2,
        Role3,
        Role4,
        Role5,
        Role6
    }

    public enum Modes
    {
        Mode1,
        Mode2,
        Mode4,
        Mode5,
        Mode6,
        Mode7,
        Mode8,
    }

    public enum ModelValidationMessages
    {
        StartDateAfterEndDate,
        ModeDatesRangBetweenStartEndDate,
    }

    public enum DashboardStoreSessionTypes
    {
        OpenSession=1,
        ClosedSessions=2
    }

    public enum SupplierModes
    {
        Mode1,
        Mode2,
        Mode3,
        Mode4,
        Mode5,
        Mode6,
        Mode7,
        Mode8,
    }
}
