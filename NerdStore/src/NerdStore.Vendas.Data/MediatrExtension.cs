﻿using NerdStore.Core.Communication.Mediator;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Vendas.Data
{
    public static class MediatrExtension
    {
        public static async Task PublicarEventos(this IMediatrHandler mediator, VendasContext context)
        {
            var domainEntities = context.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.Notificacoes != null && x.Entity.Notificacoes.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.Notificacoes)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.LimparEventos());

            var tasks = domainEvents
                .Select(async (domainEvent) =>
                {
                    await mediator.PublicarEvento(domainEvent);
                });
            await Task.WhenAll(tasks);
        }
    }
}
