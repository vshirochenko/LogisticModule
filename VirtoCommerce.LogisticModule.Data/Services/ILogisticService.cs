﻿using System;
using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.LogisticModule.Data.Dtos;

namespace VirtoCommerce.LogisticModule.Data.Services
{
    public interface ILogisticService
    {
        FulfillmentCenterDto GetNearestFulfillmentCenter(GettingNearestCenterRequestDto centerRequest);

        double GetDistanceBetweenTwoAddresses(string postalCodeFrom, string postalCodeTo);
    }
}