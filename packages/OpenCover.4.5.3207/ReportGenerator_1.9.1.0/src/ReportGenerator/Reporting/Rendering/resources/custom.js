function roundNumber(number, precision) {
    return Math.floor(number * Math.pow(10, precision)) / Math.pow(10, precision);
}

function getNthOrLastIndexOf(text, substring, n) {
    var times = 0, index = -1, currentIndex = -1;

    while (times < n) {
        currentIndex = text.indexOf(substring, index + 1);
        if (currentIndex === -1) {
            break;
        } else {
            index = currentIndex;
        }

        times++;
    }

    return index;
}

function SummaryView() {
    var self = this;

    function ClassViewModel(
        name,
        reportPath,
        coveredLines,
        uncoveredLines,
        coverableLines,
        coverageType,
        methodCoverage,
        filterObservable
    ) {
        var self = this;
        self.isNamespace = false;
        self.name = name;
        self.parent = ko.observable(null);
        self.reportPath = reportPath;
        self.coveredLines = ko.observable(coveredLines);
        self.uncoveredLines = ko.observable(uncoveredLines);
        self.coverableLines = ko.observable(coverableLines);
        self.coverageType = ko.observable(coverageType);

        if (coverableLines === 0) {
            self.coverage = ko.observable(isNaN(methodCoverage) ? NaN : methodCoverage);
        } else {
            self.coverage = ko.observable(roundNumber((100 * coveredLines) / coverableLines, 1));
        }

        self.filtered = ko.computed(function () {
            var filter = filterObservable();
            return filter === '' || self.name.toLowerCase().indexOf(filter) > -1;
        });

        self.visible = ko.computed(function () {
            return self.filtered()
                && (self.parent() === null || !self.parent().collapsed())
                && (self.parent() === null || self.parent().parent === null || !self.parent().parent.collapsed());
        });
    }

    function CodeElementViewModel(name, filterObservable, parent) {
        var self = this;
        self.isNamespace = true;
        self.name = name;
        self.filterObservable = filterObservable;
        self.parent = parent;
        self.subelements = ko.observableArray([]);
        self.coverageType = translations.LineCoverage;

        self.coveredLines = ko.computed(function () {
            var i, l, sum = 0;
            for (i = 0, l = self.subelements().length; i < l; i++) {
                sum += self.subelements()[i].coveredLines();
            }
            return sum;
        });

        self.uncoveredLines = ko.computed(function () {
            var i, l, sum = 0;
            for (i = 0, l = self.subelements().length; i < l; i++) {
                sum += self.subelements()[i].uncoveredLines();
            }
            return sum;
        });

        self.coverableLines = ko.computed(function () {
            var i, l, sum = 0;
            for (i = 0, l = self.subelements().length; i < l; i++) {
                sum += self.subelements()[i].coverableLines();
            }
            return sum;
        });

        self.coverage = ko.computed(function () {
            if (self.coverableLines() === 0) {
                return NaN;
            }

            return roundNumber((100 * self.coveredLines()) / self.coverableLines(), 1);
        });

        self.collapsed = ko.observable(name.indexOf('Test') > -1 && parent === null);

        self.filtered = ko.computed(function () {
            var i, l, filter;
            for (i = 0, l = self.subelements().length; i < l; i++) {
                if (self.subelements()[i].filtered()) {
                    return true;
                }
            }

            filter = filterObservable();
            return filter === '' || self.name.toLowerCase().indexOf(filter) > -1;
        });

        self.visible = ko.computed(function () {
            return self.filtered() && (self.parent === null || !self.parent.collapsed());
        });

        self.addSubElement = function (element) {
            self.subelements.push(element);
        };

        self.insertClass = function (clazz, grouping) {
            var groupingDotIndex, groupedNamespace, i, l, subNamespace;

            if (grouping === undefined) {
                clazz.parent(self);
                self.subelements.push(clazz);
                return;
            }

            groupingDotIndex = getNthOrLastIndexOf(clazz.name, '.', grouping);
            groupedNamespace = groupingDotIndex === -1 ? '-' : clazz.name.substr(0, groupingDotIndex);

            for (i = 0, l = self.subelements().length; i < l; i++) {
                if (self.subelements()[i].name === groupedNamespace) {
                    self.subelements()[i].insertClass(clazz);
                    return;
                }
            }

            subNamespace = new CodeElementViewModel(groupedNamespace, self.filterObservable, self);
            self.addSubElement(subNamespace);
            subNamespace.insertClass(clazz);
        };

        self.collapse = function () {
            var i, l, element;

            self.collapsed(true);

            for (i = 0, l = self.subelements().length; i < l; i++) {
                element = self.subelements()[i];

                if (element.isNamespace) {
                    element.collapse();
                }
            }
        };

        self.expand = function () {
            var i, l, element;

            self.collapsed(false);

            for (i = 0, l = self.subelements().length; i < l; i++) {
                element = self.subelements()[i];

                if (element.isNamespace) {
                    element.expand();
                }
            }
        };

        self.toggleCollapse = function () {
            self.collapsed(!self.collapsed());
        };

        self.changeSorting = function (sortby, ascending) {
            var smaller = ascending ? -1 : 1, bigger = ascending ? 1 : -1, i, l, element;

            if (sortby === 'name') {
                self.subelements.sort(function (left, right) {
                    return left.name === right.name ? 0 : (left.name < right.name ? smaller : bigger);
                });
            } else {
                if (self.subelements().length > 0 && self.subelements()[0].isNamespace) {
                    // Top level elements are resorted ASC by name if other sort columns than 'name' is selected
                    self.subelements.sort(function (left, right) {
                        return left.name === right.name ? 0 : (left.name < right.name ? -1 : 1);
                    });
                } else {
                    if (sortby === 'covered') {
                        self.subelements.sort(function (left, right) {
                            return left.coveredLines() === right.coveredLines() ?
                                    0
                                    : (left.coveredLines() < right.coveredLines() ? smaller : bigger);
                        });
                    } else if (sortby === 'uncovered') {
                        self.subelements.sort(function (left, right) {
                            return left.uncoveredLines() === right.uncoveredLines() ?
                                    0
                                    : (left.uncoveredLines() < right.uncoveredLines() ? smaller : bigger);
                        });
                    } else if (sortby === 'coverable') {
                        self.subelements.sort(function (left, right) {
                            return left.coverableLines() === right.coverableLines() ?
                                    0
                                    : (left.coverableLines() < right.coverableLines() ? smaller : bigger);
                        });
                    } else if (sortby === 'coverage') {
                        self.subelements.sort(function (left, right) {
                            return left.coverage() === right.coverage() ?
                                    0
                                    : (left.coverage() < right.coverage() ? smaller : bigger);
                        });
                    }
                }
            }

            for (i = 0, l = self.subelements().length; i < l; i++) {
                element = self.subelements()[i];

                if (element.isNamespace) {
                    element.changeSorting(sortby, ascending);
                }
            }
        };
    }

    function SummaryViewModel() {
        var self = this;
        self.assemblies = ko.observableArray([]);
        self.sortby = ko.observable('name');
        self.sortorder = ko.observable('asc');
        self.filter = ko.observable('');
        self.throttledFilter = ko.computed(function () { return self.filter().toLowerCase(); })
            .extend({ throttle: 400 });
        self.grouping = ko.observable(0);
        self.groupingMaximum = 1;
        self.throttledGrouping = ko.computed(self.grouping)
            .extend({ throttle: 400 });
        self.groupingDescription = ko.computed(function () {
            if (self.grouping() === -1) {
                return translations.noGrouping;
            }

            if (self.grouping() === 0) {
                return translations.byAssembly;
            }

            return translations.byNamespace + ' ' + self.grouping();
        });

        self.collapseAll = function () {
            var i, l;
            for (i = 0, l = self.assemblies().length; i < l; i++) {
                self.assemblies()[i].collapse();
            }
        };

        self.expandAll = function () {
            var i, l;
            for (i = 0, l = self.assemblies().length; i < l; i++) {
                self.assemblies()[i].expand();
            }
        };

        self.changeSorting = function (data, event, sortby) {
            var i, l, smaller, bigger;

            if (sortby === self.sortby()) {
                self.sortorder(self.sortorder() === 'asc' ? 'desc' : 'asc');

                // Top level elements are only sorted by name, other sort columns are ignored
                if (sortby === 'name') {
                    smaller = self.sortorder() === 'asc' ? -1 : 1;
                    bigger = self.sortorder() === 'asc' ? 1 : -1;
                    self.assemblies.sort(function (left, right) {
                        return left.name === right.name ? 0 : (left.name < right.name ? smaller : bigger);
                    });
                }
            } else {
                // Top level elements are resorted ASC by name if other sort columns than 'name' is selected
                if (self.sortby() === 'name' && self.sortorder() === 'desc') {
                    self.assemblies.sort(function (left, right) {
                        return left.name === right.name ? 0 : (left.name < right.name ? -1 : 1);
                    });
                }

                self.sortby(sortby);
                self.sortorder('asc');
            }

            for (i = 0, l = self.assemblies().length; i < l; i++) {
                self.assemblies()[i].changeSorting(self.sortby(), self.sortorder() === 'asc');
            }
        };

        self.throttledGrouping.subscribe(function (grouping) {
            self.updateAssemblies(grouping);
        });

        self.updateAssemblies = function (grouping) {
            var i, l, j, l2, assemblyElement, parentElement, cls, classViewModel, smaller, bigger;

            self.assemblies.removeAll();

            if (grouping === 0) { // Group by assembly
                for (i = 0, l = assemblies.length; i < l; i++) {
                    assemblyElement = new CodeElementViewModel(assemblies[i].name, self.throttledFilter, null);
                    self.assemblies.push(assemblyElement);

                    for (j = 0, l2 = assemblies[i].classes.length; j < l2; j++) {
                        cls = assemblies[i].classes[j];
                        classViewModel = new ClassViewModel(
                            cls.name,
                            cls.reportPath,
                            cls.coveredLines,
                            cls.uncoveredLines,
                            cls.coverableLines,
                            cls.coverageType,
                            cls.methodCoverage,
                            self.throttledFilter
                        );
                        assemblyElement.insertClass(classViewModel);
                    }
                }
            } else if (grouping === -1) { // No grouping
                parentElement = new CodeElementViewModel(translations.all, self.throttledFilter, null);
                self.assemblies.push(parentElement);

                for (i = 0, l = assemblies.length; i < l; i++) {
                    for (j = 0, l2 = assemblies[i].classes.length; j < l2; j++) {
                        cls = assemblies[i].classes[j];
                        classViewModel = new ClassViewModel(
                            cls.name,
                            cls.reportPath,
                            cls.coveredLines,
                            cls.uncoveredLines,
                            cls.coverableLines,
                            cls.coverageType,
                            cls.methodCoverage,
                            self.throttledFilter
                        );
                        parentElement.insertClass(classViewModel);
                    }
                }
            } else { // Group by assembly and namespace
                for (i = 0, l = assemblies.length; i < l; i++) {
                    assemblyElement = new CodeElementViewModel(assemblies[i].name, self.throttledFilter, null);
                    self.assemblies.push(assemblyElement);

                    for (j = 0, l2 = assemblies[i].classes.length; j < l2; j++) {
                        cls = assemblies[i].classes[j];
                        classViewModel = new ClassViewModel(
                            cls.name,
                            cls.reportPath,
                            cls.coveredLines,
                            cls.uncoveredLines,
                            cls.coverableLines,
                            cls.coverageType,
                            cls.methodCoverage,
                            self.throttledFilter
                        );
                        assemblyElement.insertClass(classViewModel, grouping);
                    }
                }
            }

            if (self.sortby() === 'name') {
                smaller = self.sortorder() === 'asc' ? -1 : 1;
                bigger = self.sortorder() === 'asc' ? 1 : -1;
            } else {
                smaller = -1;
                bigger = 1;
            }
            
            self.assemblies.sort(function (left, right) {
                return left.name === right.name ? 0 : (left.name < right.name ? smaller : bigger);
            });

            for (i = 0, l = self.assemblies().length; i < l; i++) {
                self.assemblies()[i].changeSorting(self.sortby(), self.sortorder() === 'asc');
            }
        };

        self.initGroupingMaximum = function () {
            var i, l, j, l2;

            for (i = 0, l = assemblies.length; i < l; i++) {
                for (j = 0, l2 = assemblies[i].classes.length; j < l2; j++) {

                    self.groupingMaximum = Math.max(
                        self.groupingMaximum,
                        (assemblies[i].classes[j].name.match(/\./g) || []).length
                    );
                }
            }
        };

        self.initGroupingMaximum();
        self.updateAssemblies(self.grouping());
    }

    var enableFiltering = function () {
        $('#showcustomizebox').hide();
        $('#customizebox').show();

        $('#summaryTable tbody').html('');

        var summaryViewModel = new SummaryViewModel();

        $('#namespaceslider').slider({
            value: summaryViewModel.grouping(),
            min: -1,
            max: summaryViewModel.groupingMaximum,
            step: 1,
            slide: function (event, ui) {
                summaryViewModel.grouping(ui.value);
            }
        });

        ko.applyBindings(summaryViewModel);

        return false;
    };

    self.initialize = function () {
        var i, l, j, l2, counter;

        $('#showcustomizeboxbutton').on('click', enableFiltering);

        counter = 0;

        for (i = 0, l = assemblies.length; i < l; i++) {
            for (j = 0, l2 = assemblies[i].classes.length; j < l2; j++) {
                if (counter++ > 1000) {
                    return;
                }
            }
        }

        enableFiltering();
    };
}

function ClassView() {
    var self = this;

    function switchTestMethod() {
        var testMethodName, lines, i, l, coverageData, lineAnalysis, cells;

        testMethodName = $(this).val();
        lines = $('.lineAnalysis tr');

        for (i = 1, l = lines.length; i < l; i++) {
            coverageData = JSON.parse(lines[i].getAttribute('data-coverage').replace(/'/g, '"'));
            lineAnalysis = coverageData[testMethodName];
            cells = $('td', lines[i]);
            if (lineAnalysis === null) {
                lineAnalysis = coverageData.AllTestMethods;
                if (lineAnalysis.LVS !== 'gray') {
                    cells[0].setAttribute('class', 'red');
                    cells[1].innerText = '0';
                    cells[3].setAttribute('class', 'lightred');
                }
            } else {
                cells[0].setAttribute('class', lineAnalysis.LVS);
                cells[1].innerText = lineAnalysis.VC;
                cells[3].setAttribute('class', 'light' + lineAnalysis.LVS);
            }
        }
    }

    function togglePin() {
        $('#testmethods').toggleClass('pinned');
        return false;
    }

    self.initialize = function () {
        $('input').on('change', switchTestMethod);

        $('#pin').on('click', togglePin);

        if (navigator.appName === 'Microsoft Internet Explorer') {
            $('#pinheader').css('width', 'auto');
        }
    };
}

$(function () {
    if (typeof assemblies !== 'undefined') {
        new SummaryView().initialize();
    }

    new ClassView().initialize();
});