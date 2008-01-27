SOURCES_EXPANDED = $(foreach expr, $(SOURCES), $(wildcard $(expr)))
SOURCES_BUILD = $(addprefix $(srcdir)/, $(SOURCES_EXPANDED))
SOURCES_BUILD += $(top_srcdir)/src/AssemblyInfo.cs

RESOURCES_EXPANDED = $(foreach expr, $(RESOURCES), $(wildcard $(expr)))
RESOURCES_EXPANDED_FULL = $(addprefix $(srcdir)/, $(RESOURCES_EXPANDED))
RESOURCES_BUILD = $(foreach resource, $(RESOURCES_EXPANDED_FULL), \
	-resource:$(resource),$(notdir $(resource)))

ASSEMBLY_EXTENSION = $(strip $(patsubst library, dll, $(TARGET)))
ASSEMBLY_FILE = $(top_builddir)/bin/$(ASSEMBLY).$(ASSEMBLY_EXTENSION)

INSTALL_DIR_RESOLVED = $(firstword $(subst , $(DEFAULT_INSTALL_DIR), $(INSTALL_DIR)))

moduledir = $(INSTALL_DIR_RESOLVED)
module_SCRIPTS = 

OUTPUT_FILES = \
	$(ASSEMBLY_FILE) \
	$(ASSEMBLY_FILE).mdb

all: $(ASSEMBLY_FILE)

$(ASSEMBLY_FILE): $(SOURCES_BUILD) $(RESOURCES_EXPANDED_FULL)
	@mkdir -p $(top_builddir)/bin
	@echo "Compiling $(notdir $@)..."
	@$(BUILD) -target:$(TARGET) -out:$@ $(LINK) $(RESOURCES_BUILD) $(SOURCES_BUILD)

EXTRA_DIST = $(SOURCES_BUILD) $(RESOURCES_EXPANDED_FULL)

CLEANFILES = $(OUTPUT_FILES) *.dll *.mdb *.exe
MAINTAINERCLEANFILES = Makefile.in
