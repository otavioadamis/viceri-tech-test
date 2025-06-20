using SuperHeroes.Data;

public static class DbInitializer
{
    public static void Seed(AppDbContext context)
    {
        if (!context.Superpoderes.Any())
        {
            context.Superpoderes.AddRange(
                new SuperPoder { Superpoder = "Super Força", Descricao = "Força sobre-humana" },
                new SuperPoder { Superpoder = "Invisibilidade", Descricao = "Fica invisível ao olho humano" },
                new SuperPoder { Superpoder = "Voo", Descricao = "Capaz de voar longas distâncias" },
                new SuperPoder { Superpoder = "Velocidade", Descricao = "Corre em altíssima velocidade" },
                new SuperPoder { Superpoder = "Telepatia", Descricao = "Ler e controlar pensamentos" },
                new SuperPoder { Superpoder = "Manipulação do Tempo", Descricao = "Controla o fluxo do tempo" },
                new SuperPoder { Superpoder = "Regeneração", Descricao = "Cura rápida de ferimentos" },
                new SuperPoder { Superpoder = "Elasticidade", Descricao = "Pode esticar o corpo de formas impossíveis" },
                new SuperPoder { Superpoder = "Controle da Gravidade", Descricao = "Pode aumentar ou diminuir a gravidade local" },
                new SuperPoder { Superpoder = "Transmutação", Descricao = "Transforma matéria em outra" },
                new SuperPoder { Superpoder = "Intangibilidade", Descricao = "Passar através de objetos sólidos" },
                new SuperPoder { Superpoder = "Invulnerabilidade", Descricao = "Imune a danos físicos" },
                new SuperPoder { Superpoder = "Controle Mental", Descricao = "Influenciar ações de outras pessoas" },
                new SuperPoder { Superpoder = "Furtividade", Descricao = "Movimentar-se sem ser detectado" },
                new SuperPoder { Superpoder = "Armadura Energética", Descricao = "Cria uma barreira protetora ao redor do corpo" },
                new SuperPoder { Superpoder = "Controle Elemental", Descricao = "Manipula fogo, água, terra e ar" },
                new SuperPoder { Superpoder = "Visão de Raio-X", Descricao = "Ver através de objetos opacos" },
                new SuperPoder { Superpoder = "Teletransporte", Descricao = "Se teletransporta instantaneamente para qualquer lugar" },
                new SuperPoder { Superpoder = "Duplicação", Descricao = "Cria cópias de si mesmo" },
                new SuperPoder { Superpoder = "Absorção de Energia", Descricao = "Absorve energia para fortalecer-se" }
            );

            context.SaveChanges();
        }
    }
}
