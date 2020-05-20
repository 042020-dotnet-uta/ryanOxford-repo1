using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace GettingStartedLib
{
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface ICalculator
    {
        [OperationContract]
        List<Fruit> AddToList(List<Fruit> fruits, string fruit);
        [OperationContract]
        Fruit ExtractFromList(List<Fruit> fruits, string fruit);
        [OperationContract]
        int CountList(List<Fruit> fruits);
        [OperationContract]
        Fruit CreateFruit(string name);
        [OperationContract]
        List<Fruit> CreateList();
    }
}