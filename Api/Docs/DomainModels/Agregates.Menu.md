# Domain Models

## Menu

```Csharp
class Menu{
    Menu Create();
    void AddDinner(Dinner dinner);
    void RemoveDinner(Dinner dinner);
    void UpdateSection(MenuSection section);
}
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Menu do Judeu",
    "description": "Menu contendo as comidas preparadas pelo judeu",
    "averageRating": 5.0,
    "sections": [
        {
            "id": "00000000-0000-0000-0000-000000000000",
            "name": "Panqueca frango com catupiry",
            "description": "uma comida estranha desde a textura ao sabor",
            "items": [
                {
                    "id": "00000000-0000-0000-0000-000000000000",
                    "name": "Panqueca",
                    "description": "uma massa feita a partir de ovos, leite e farinha de trigo",
                    "price": 20
                },
                {
                    "id": "00000000-0000-0000-0000-000000000000",
                    "name": "frango frito",
                    "description": "peito de frango desossado frito na panela e desfiado",
                    "price": 20
                },
                {
                    "id": "00000000-0000-0000-0000-000000000000",
                    "name": "Catupiry",
                    "description": "requeijão comprado no koch",
                    "price": 20
                }
            ]
        }
    ],
    "host-Id": "00000000-0000-0000-0000-000000000000",
    "dinnerIds":[
        "00000000-0000-0000-0000-000000000000",
    ],
    "menuReviewIds": [
        "00000000-0000-0000-0000-000000000000",
    ]

}
```
