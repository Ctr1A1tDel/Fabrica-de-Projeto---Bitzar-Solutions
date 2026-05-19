import json
from rag.retriever import buscar_chunks


def construir_prompt(dados: dict, tipo_grafico: str = "auto") -> str:
    query_rag = f"definições e regras de negócio para gráfico {tipo_grafico}"
    contextos = buscar_chunks(query_rag, top_k=3)
    contexto_str = (
        "\n\n".join(contextos) if contextos else "Nenhum contexto adicional disponível."
    )

    return f"""
CONTEXTO DE NEGÓCIO:
{contexto_str}

DADOS RECEBIDOS:
{json.dumps(dados, ensure_ascii=False, indent=2)}

TAREFA:
Analise os dados acima e retorne um JSON para ApexCharts com tipo "{tipo_grafico}".

INSTRUÇÕES:
1. Identifique as categorias (eixo X) e valores numéricos (eixo Y)
2. Agrupe séries quando houver múltiplas métricas comparáveis
3. Use os nomes originais dos campos como labels
4. Se tipo for "auto", escolha entre bar, line, area ou pie conforme os dados
5. Não omita nenhum ponto de dado presente

Retorne apenas o JSON, sem texto adicional.
""".strip()
