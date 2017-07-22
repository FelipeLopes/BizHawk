#ifdef PPU_CPP

uint8* PPU::Cache::tile_2bpp(unsigned tile) {
  if(tilevalid[0][tile] == 0) {
    tilevalid[0][tile] = 1;
    uint8 *output = (uint8*)tiledata[0] + (tile << 6);
    unsigned offset = tile << 4;
    unsigned y = 8;
    unsigned color, d0, d1;
    while(y--) {
      d0 = ppu.vram[offset +  0];
      d1 = ppu.vram[offset +  1];
      #define render_line(mask) \
        color  = !!(d0 & mask) << 0; \
        color |= !!(d1 & mask) << 1; \
        *output++ = color
      render_line(0x80);
      render_line(0x40);
      render_line(0x20);
      render_line(0x10);
      render_line(0x08);
      render_line(0x04);
      render_line(0x02);
      render_line(0x01);
      #undef render_line
      offset += 2;
    }
  }
  return tiledata[0] + (tile << 6);
}

uint8* PPU::Cache::tile_4bpp(unsigned tile) {
  if(tilevalid[1][tile] == 0) {
    tilevalid[1][tile] = 1;
    uint8 *output = (uint8*)tiledata[1] + (tile << 6);
    unsigned offset = tile << 5;
    unsigned y = 8;
    unsigned color, d0, d1, d2, d3;
    while(y--) {
      d0 = ppu.vram[offset +  0];
      d1 = ppu.vram[offset +  1];
      d2 = ppu.vram[offset + 16];
      d3 = ppu.vram[offset + 17];
      #define render_line(mask) \
        color  = !!(d0 & mask) << 0; \
        color |= !!(d1 & mask) << 1; \
        color |= !!(d2 & mask) << 2; \
        color |= !!(d3 & mask) << 3; \
        *output++ = color
      render_line(0x80);
      render_line(0x40);
      render_line(0x20);
      render_line(0x10);
      render_line(0x08);
      render_line(0x04);
      render_line(0x02);
      render_line(0x01);
      #undef render_line
      offset += 2;
    }
  }
  return tiledata[1] + (tile << 6);
}

uint8* PPU::Cache::tile_8bpp(unsigned tile) {
  if(tilevalid[2][tile] == 0) {
    tilevalid[2][tile] = 1;
    uint8 *output = (uint8*)tiledata[2] + (tile << 6);
    unsigned offset = tile << 6;
    unsigned y = 8;
    unsigned color, d0, d1, d2, d3, d4, d5, d6, d7;
    while(y--) {
      d0 = ppu.vram[offset +  0];
      d1 = ppu.vram[offset +  1];
      d2 = ppu.vram[offset + 16];
      d3 = ppu.vram[offset + 17];
      d4 = ppu.vram[offset + 32];
      d5 = ppu.vram[offset + 33];
      d6 = ppu.vram[offset + 48];
      d7 = ppu.vram[offset + 49];
      #define render_line(mask) \
        color  = !!(d0 & mask) << 0; \
        color |= !!(d1 & mask) << 1; \
        color |= !!(d2 & mask) << 2; \
        color |= !!(d3 & mask) << 3; \
        color |= !!(d4 & mask) << 4; \
        color |= !!(d5 & mask) << 5; \
        color |= !!(d6 & mask) << 6; \
        color |= !!(d7 & mask) << 7; \
        *output++ = color
      render_line(0x80);
      render_line(0x40);
      render_line(0x20);
      render_line(0x10);
      render_line(0x08);
      render_line(0x04);
      render_line(0x02);
      render_line(0x01);
      #undef render_line
      offset += 2;
    }
  }
  return tiledata[2] + (tile << 6);
}

uint8* PPU::Cache::tile(unsigned bpp, unsigned tile) {
  switch(bpp) {
    case 0: return tile_2bpp(tile);
    case 1: return tile_4bpp(tile);
    case 2: return tile_8bpp(tile);
  }
    return 0;
}

PPU::Cache::Cache(PPU &self) : self(self) {
  tiledata[0] = (uint8*)alloc_invisible(262144);
  tiledata[1] = (uint8*)alloc_invisible(131072);
  tiledata[2] = (uint8*)alloc_invisible(65536);
  tilevalid[0] = (uint8*)alloc_invisible(4096);
  tilevalid[1] = (uint8*)alloc_invisible(2048);
  tilevalid[2] = (uint8*)alloc_invisible(1024);
}

PPU::Cache::invalidate() {
  memset(tilevalid[0], 0, 4096);
  memset(tilevalid[1], 0, 2048);
  memset(tilevalid[2], 0, 1024);
}

PPU::Cache::~Cache()
{
	abort();
}

#endif
