using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.MedicalFiles;
using Presentation.Services.Http.Connection;
using Requests.Appointments;
using RestSharp;

namespace Presentation.Services.Http
{
    public class AppointmentsService
    {
        private readonly IRestComposer _restComposer;

        public AppointmentsService(IRestComposer restComposer)
        {
            _restComposer = restComposer;
        }

        public async Task<IEnumerable<MedicalAppointmentResponse>> GetAppointments(
            CancellationToken cancellation)
        {
            const string endpoint = "/appointments";
            return await _restComposer.GetAsync<IEnumerable<MedicalAppointmentResponse>>(
                endpoint, cancellation);
        }

        public async Task RegisterAppointment(CreateMedicalAppointmentRequest medicalAppointment, CancellationToken cancellation)
        {
            const string endpoint = "/appointments";
            IRestRequest request = new RestRequest(endpoint).AddJsonBody(medicalAppointment);
            await _restComposer.Post<Unit>(request, cancellation);
        }
    }
}
