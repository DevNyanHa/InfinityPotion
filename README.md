> ⚠️ Warning<br>
> 이 모드는 개발중입니다 V1의 경고를 무시하고 V1을 사용해주세요<br>
> This mod is under development. Please ignore the warnings of V1 and use V1.

## Infinity Potion V2

[![Discord](https://img.shields.io/badge/Discord-black?logo=discord)](https://discord.gg/XbxTxdf7jh)
[![Github](https://img.shields.io/badge/Github-DevNyanHa-white?logo=github)](https://github.com/DevNyanHa/InfinityPotion)
![GitHub Release](https://img.shields.io/github/v/release/DevNyanHa/InfinityPotion)
![License](https://img.shields.io/github/license/DevNyanHa/InfinityPotion?branch=v2)

This mod makes all **consumable items** — such as potions, boss summoning items, and ammo — **unlimited**.
If you want to **change the mod settings**, you can **easily** do so at
**Settings → Mod Settings → InfinityPotion → Main Config**.

## Features

...

## Code Dependency

```
+------------------+            +-------------+       +-----------+
| INFRepository.cs | ----+----> | INFItem.cs  | <---- | INFState  |
+------------------+     |      +------+------+       +-----+-----+
						 |             |                    |
						 |             V                    |
						 |      +--------------+            |
						 +----> | INFToggle.cs | <----------+
								+--------------+            |
								                            |
								+------------------+        |
								| INFDecoration.cs | <------+
								+------------------+
```

## Infinity Item

...