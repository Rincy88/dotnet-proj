using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.MedicalFiles;
using Domain.MedicalFiles.Repositories;

namespace Application.MedicalFiles.FindById
{
    public class AppointmentFinder
    {
        private readonly IMedicalAppointmentRepository _repository;

        public AppointmentFinder(IMedicalAppointmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<MedicalAppointment> FindAppointmentById(string id,
            CancellationToken cancellation)
        {
            return await _repository.FindById(Guid.Parse(id), cancellation);
        }
    }
}
