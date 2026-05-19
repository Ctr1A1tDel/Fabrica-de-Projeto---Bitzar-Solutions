import json
import ollama
from fastapi import APIRouter, HTTPException
from models.schemas import ChatRequest
from rag.prompt_builder import construir_prompt

router = APIRouter(tags=["IA"])

# JSON Schema exato esperado pelo ApexCharts
APEX_SCHEMA = {
    "type": "object",
    "properties": {
        "chartType": {"type": "string", "enum": ["bar", "line", "pie", "area"]},
        "series": {
            "type": "array",
            "items": {
                "type": "object",
                "properties": {
                    "name": {"type": "string"},
                    "data": {"type": "array", "items": {"type": "number"}},
                },
                "required": ["name", "data"],
            },
        },
        "categories": {"type": "array", "items": {"type": "string"}},
        "title": {"type": "string"},
    },
    "required": ["chartType", "series", "categories", "title"],
}


@router.post("/chat")
async def chat(req: ChatRequest):
    prompt = construir_prompt(req.dados, req.tipo_grafico)

    try:
        response = ollama.chat(
            model="bitzar-rag",
            format=APEX_SCHEMA,
            messages=[{"role": "user", "content": prompt}],
        )
        chart_data = json.loads(response.message.content)
        return chart_data

    except json.JSONDecodeError:
        raise HTTPException(status_code=500, detail="Modelo retornou JSON inválido")
    except Exception as e:
        raise HTTPException(status_code=500, detail=str(e))
