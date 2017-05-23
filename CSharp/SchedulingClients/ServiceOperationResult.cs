using System;
using aSR = SchedulingClients.AgentServiceReference;
using jBSR = SchedulingClients.JobBuilderServiceReference;
using jSSR = SchedulingClients.JobStateServiceReference;
using jsSSR = SchedulingClients.JobsStateServiceReference;
using rSR = SchedulingClients.RoadmapServiceReference;
using sSR = SchedulingClients.ServicingServiceReference;

namespace SchedulingClients
{
    public struct ServiceOperationResult
    {
        private readonly Exception clientException;

        private readonly uint serviceCode;

        private readonly Exception serviceException;

        private readonly string serviceString;

        public ServiceOperationResult(uint serviceCode, string serviceString, Exception serviceException, Exception clientException)
        {
            this.serviceCode = serviceCode;
            this.serviceString = serviceString;
            this.serviceException = serviceException;
            this.clientException = clientException;
        }

        public Exception ClientException { get { return clientException; } }

        public bool IsClientError
        {
            get { return ClientException != null; }
        }

        public bool IsServiceError
        {
            get { return serviceCode != (uint)aSR.ServiceCode.NOERROR && serviceCode != (uint)aSR.ServiceCode.CLIENTEXCEPTION; }
        }

        public bool IsSuccessfull
        {
            get { return (!IsServiceError && !IsClientError); }
        }

        public uint ServiceCode { get { return serviceCode; } }

        public Exception ServiceException { get { return serviceException; } }

        public string ServiceString { get { return serviceString; } }

        public static ServiceOperationResult FromClientException(Exception ex)
        {
            if (ex == null)
            {
                throw new ArgumentNullException();
            }

            return new ServiceOperationResult
                (
                    (uint)aSR.ServiceCode.CLIENTEXCEPTION,
                    aSR.ServiceCode.CLIENTEXCEPTION.ToString(),
                    null,
                    ex
                );
        }

        public static ServiceOperationResult FromServiceCallData(rSR.ServiceCallData serviceCallData)
        {
            Exception serviceException = string.IsNullOrEmpty(serviceCallData.Message) ? null : new Exception(serviceCallData.Message);

            return new ServiceOperationResult
                (
                    (uint)serviceCallData.ServiceCode,
                    serviceCallData.ServiceCode.ToString(),
                    serviceException,
                    null
                );
        }

        public static ServiceOperationResult FromServiceCallData(sSR.ServiceCallData serviceCallData)
        {
            Exception serviceException = string.IsNullOrEmpty(serviceCallData.Message) ? null : new Exception(serviceCallData.Message);

            return new ServiceOperationResult
                (
                    (uint)serviceCallData.ServiceCode,
                    serviceCallData.ServiceCode.ToString(),
                    serviceException,
                    null
                );
        }

        public static ServiceOperationResult FromServiceCallData(jsSSR.ServiceCallData serviceCallData)
        {
            Exception serviceException = string.IsNullOrEmpty(serviceCallData.Message) ? null : new Exception(serviceCallData.Message);

            return new ServiceOperationResult
                (
                    (uint)serviceCallData.ServiceCode,
                    serviceCallData.ServiceCode.ToString(),
                    serviceException,
                    null
                );
        }

        public static ServiceOperationResult FromServiceCallData(jSSR.ServiceCallData serviceCallData)
        {
            Exception serviceException = string.IsNullOrEmpty(serviceCallData.Message) ? null : new Exception(serviceCallData.Message);

            return new ServiceOperationResult
                (
                    (uint)serviceCallData.ServiceCode,
                    serviceCallData.ServiceCode.ToString(),
                    serviceException,
                    null
                );
        }

        public static ServiceOperationResult FromServiceCallData(aSR.ServiceCallData serviceCallData)
        {
            Exception serviceException = string.IsNullOrEmpty(serviceCallData.Message) ? null : new Exception(serviceCallData.Message);

            return new ServiceOperationResult
                (
                    (uint)serviceCallData.ServiceCode,
                    serviceCallData.ServiceCode.ToString(),
                    serviceException,
                    null
                );
        }

        public static ServiceOperationResult FromServiceCallData(jBSR.ServiceCallData serviceCallData)
        {
            Exception serviceException = string.IsNullOrEmpty(serviceCallData.Message) ? null : new Exception(serviceCallData.Message);

            return new ServiceOperationResult
                (
                    (uint)serviceCallData.ServiceCode,
                    serviceCallData.ServiceCode.ToString(),
                    serviceException,
                    null
                );
        }

        public static bool operator !=(ServiceOperationResult result, bool value)
        {
            return !(result == value);
        }

        public static bool operator ==(ServiceOperationResult result, bool value)
        {
            return result.IsSuccessfull == value;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ServiceOperationResult))
            {
                return false;
            }

            ServiceOperationResult other = (ServiceOperationResult)obj;

            return ServiceCode == other.ServiceCode;
        }

        public override int GetHashCode()
        {
            int hash = 17;

            unchecked
            {
                hash += hash * 23 + serviceCode.GetHashCode();
            }
            return hash;
        }
    }
}